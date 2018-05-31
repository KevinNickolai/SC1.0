using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for defining a runtime set of objects
/// </summary>
/// <typeparam name="T">The type of the objects in the set</typeparam>
public abstract class RuntimeSet<T> : ScriptableObject {

    /// <summary>
    /// The underlying list of the set of items
    /// </summary>
    private List<T> set = new List<T>();

    /// <summary>
    /// Add an item to the runtime set
    /// </summary>
    /// <param name="t">The item to add to the set</param>
    public void Add(T t)
    {
        if (!set.Contains(t))
        {
            set.Add(t);
        }
    }

    /// <summary>
    /// Remove an item from the runtime set if it exists in the set
    /// </summary>
    /// <param name="t">The item to remove from the set</param>
    public void Remove(T t)
    {
        if (set.Contains(t))
        {
            set.Remove(t);
        }
    }
}
