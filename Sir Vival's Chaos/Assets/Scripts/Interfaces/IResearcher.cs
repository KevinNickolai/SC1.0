using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher
{

    /// <summary>
    /// the current timer
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// The timer for the current research
    /// </summary>
    public float Timer
    {
        get
        {
            return timer;
        }
    }


    public bool Researching
    {
        get
        {
            return !queue.Empty;
        }
    }

    public ResearchQueue Queue
    {
        get
        {
            return queue;
        }
    }


    public class ResearchQueue
    {
        List<LevelAbility> queue;

        const int MAX_SIZE = 4;

        /// <summary>
        /// end tracks the next available position in the queue
        /// </summary>
        int end = 0;

        /// <summary>
        /// the number of elements in the queue
        /// </summary>
        int size = 0;

        /// <summary>
        /// constructor for a research queue
        /// </summary>
        public ResearchQueue()
        {
            queue = new List<LevelAbility>(MAX_SIZE);

            for(int i = 0; i < MAX_SIZE; ++i)
            {
                queue.Add(null);
            }
        }

        /// <summary>
        /// Add a LevelAbility to the ResearchQueue
        /// </summary>
        /// <param name="toAdd">the LevelAbility we add to the queue</param>
        /// <returns>true if the LevelAbility was added successfully, false otherwise</returns>
        public bool Push(LevelAbility toAdd)
        {
            //check that the queue isn't full
            if (size < MAX_SIZE)
            {
                ++size;

                //add the item to the end of the queue, and increment the end position
                queue[end++] = toAdd;

                return true;
            }

            return false;
        }

        /// <summary>
        /// pop the top element of the ResearchQueue
        /// </summary>
        /// <returns>true if the oldest item in the queue is successfully popped, false otherwise</returns>
        public bool Pop()
        {
            //checking that there are elements to pop, since we are shifting the begin position
            if (size > 0)
            {
                queue[0].CompleteResearch();
                //decrement the size, and increment the begin position
                --size;

                //move items up in the queue
                //since size is decremented prior to this loop, the loop will never attempt
                //to access the out of range of i == size == MAX_SIZE for queue[i]
                for(int i = 1; i <= size; ++i)
                {
                    queue[i-1] = queue[i];
                }

                --end;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove an item at a relative position within the queue
        /// </summary>
        /// <param name="relativePosition">the relative position of the item to remove from the 0-indexed queue</param>
        /// <returns>true if the item was successfully removed, false otherwise</returns>
        public bool Remove(int relativePosition)
        {
            //check if it's possible to remove an element at a position within our current array bounds
            if (relativePosition < size)
            {
                //indicate to the research itself that it is no longer being researched
                queue[relativePosition].EndResearch();

                --size;

                //move items up in the queue, starting from the position of the removal
                for (int i = relativePosition; i < size; ++i)
                {
                    queue[i] = queue[i + 1];
                }

                --end;
                return true;
            }

            return false;
        }

        /// <summary>
        /// The number of elements currently in the queue
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Flag indicating if the queue is empty
        /// </summary>
        public bool Empty
        {
            get
            {
                return size == 0;
            }
        }

        /// <summary>
        /// indexer into the research queue
        /// </summary>
        /// <param name="key">the index to be looked at within the queue</param>
        /// <returns>the LevelAbility at the index key of the queue</returns>
        public LevelAbility this[int key]
        {
            get
            {
                try
                {
                    return queue[key];
                }
                catch (System.IndexOutOfRangeException)
                {
                    Debug.Log("Ability at index " + key + " Produced out of range exception; returning null ability");
                    return null;
                }
            }
        }
    }

    /// <summary>
    /// The queue used to track our research priority
    /// </summary>
    ResearchQueue queue = new ResearchQueue();

    /// <summary>
    /// Attempt to research a LevelAbility for this given researcher
    /// </summary>
    /// <param name="toResearch">The LevelAbility to attempt to research</param>
    /// <returns>true if the Researcher is able to research the LevelAbility, false otherwise</returns>
    public bool Research(LevelAbility toResearch)
    {
        return queue.Push(toResearch);
    }

    /// <summary>
    /// Attempt to cancel research at a specific position within the ResearchQueue
    /// </summary>
    /// <param name="relativePosition">the position of the research we are trying to cancel</param>
    /// <returns>true if a research at the position was cancellable and cancelled</returns>
    public bool CancelResearch(int relativePosition)
    {
        if (queue.Remove(relativePosition))
        {
            //reset timer on removal of the first slot of research
            if(relativePosition == 0)
            {
                timer = 0;
            }

            return true;
        }
        return false;
        //return queue.Remove(position);
    }


    public void AddTime(float t)
    {
        if (Researching)
        {
            timer += t;

            if(timer >= queue[0].ResearchTime)
            {
                queue.Pop();
                timer = 0;
                UIController.GetInstance().Redraw();
            }
        }
    }
}


public interface IResearcher : IAbilityUsable {
    bool Research(LevelAbility toResearch);

    bool CancelResearch(int relativePosition);

    bool Researching { get; }

    Researcher.ResearchQueue Queue { get; }

    void AddTime(float t);

    float Timer { get; }
}
