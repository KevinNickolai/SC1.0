using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a GameEvent object, used to raise an event with
/// objects that are registered with the event
/// 
/// inspiration for this class found at Unite 2017 game architecture talk here:
/// https://www.youtube.com/watch?v=raQ3iHhE_Kk
/// </summary>
[CreateAssetMenu]
public class GameEvent : ScriptableObject {
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
