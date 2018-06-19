using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ListWrapper to allow for serialization of a 2D list
/// </summary>
[System.Serializable]
public abstract class ListWrapper<T>
{
    /// <summary>
    /// The list of the List Wrapper
    /// </summary>
    [SerializeField]
    private List<T> list;

    /// <summary>
    /// Get an object at the position of the key
    /// </summary>
    /// <param name="key">the position to get </param>
    /// <returns></returns>
    public T this[int key]
    {
        get
        {
            return list[key];
        }
    }

    /// <summary>
    /// Get the size of the list for the ListWrapper
    /// </summary>
    public int Size
    {
        get
        {
            return list.Count;
        }
    }

    /// <summary>
    /// The List of the ListWrapper
    /// </summary>
    public List<T> List
    {
        get { return list; }
    }
}
