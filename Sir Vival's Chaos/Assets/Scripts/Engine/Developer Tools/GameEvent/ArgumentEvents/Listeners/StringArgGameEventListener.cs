using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringArgGameEventListener : ArgumentGameEventListener<string> {

    [System.Serializable]
    public class StringArgUnityEvent : UnityEvent<string> { }

    public StringArgGameEvent Event;
    public StringArgUnityEvent Response;

    protected override void OnEnable()
    {
        Event.RegisterListener(this);
    }

    protected override void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public override void OnEventRaised()
    {
        Response.Invoke(Event.Argument);
    }
}
