using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPanelManager : MonoBehaviour {

    private const string RESEARCH_PANES = "Research Panes";

    private ResearchPane[] panes;

    private static ResearchPanelManager instance;

    /// <summary>
    /// Max size of the ResearchPanelManager array, corresponding to the number of research panels
    /// </summary>
    const int MAX_SIZE = 4;

    public static ResearchPanelManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        
        //get all of the panes that exist in the UI component labeled with RESEARCH_PANES
        panes = GameObject.Find(RESEARCH_PANES).GetComponentsInChildren<ResearchPane>();

        ResearchPane temp;

        //sort the panes by order of their place in the queue
        for (int i = 0; i < panes.Length; ++i)
        {
            //if the current pane we're looking at isn't in the proper position,
            //we will swap the pane we are looking at with the pane in its position currently.
            if(panes[i].QueuePosition != i)
            {
                temp = panes[panes[i].QueuePosition];
                panes[panes[i].QueuePosition] = panes[i];
                panes[i] = temp;
            }

        }
    }

    public void UpdateResearch(IResearcher researcher)
    {
        int i = 0;
        for(i = 0; i < panes.Length && i < researcher.Queue.Size; ++i)
        {
            panes[i].Ability = researcher.Queue[i];
        }

        for(; i < panes.Length; ++i)
        {
            panes[i].Ability = null;
        }
    }

}
