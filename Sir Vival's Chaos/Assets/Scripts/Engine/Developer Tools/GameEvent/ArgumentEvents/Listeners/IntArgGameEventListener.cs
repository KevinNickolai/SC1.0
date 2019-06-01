using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntArgGameEventListener : ArgumentGameEventListener<int> {

    [SerializeField]
    public IntArgUnityEvent Response;
    public IntArgGameEvent Event;

    protected override void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    protected override void OnEnable()
    {
        Event.RegisterListener(this);
    }

    public override void OnEventRaised()
    {
        Response.Invoke(Event.Argument);
    }
}
