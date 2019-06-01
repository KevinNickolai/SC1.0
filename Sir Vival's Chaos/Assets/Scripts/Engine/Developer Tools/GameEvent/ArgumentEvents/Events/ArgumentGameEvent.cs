using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class ArgumentGameEvent<T> : ScriptableObject {

    private List<ArgumentGameEventListener<T>> listeners = new List<ArgumentGameEventListener<T>>();

    T arg;

    public T Argument
    {
        get
        {
            return arg;
        }
    }

    public void Raise(T argument)
    {
        arg = argument;
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(ArgumentGameEventListener<T> listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(ArgumentGameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }

}
