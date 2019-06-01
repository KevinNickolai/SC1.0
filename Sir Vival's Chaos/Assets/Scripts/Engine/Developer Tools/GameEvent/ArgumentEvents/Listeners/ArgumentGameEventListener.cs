using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public abstract class ArgumentGameEventListener<T> : MonoBehaviour {

    //public ArgumentGameEvent<T> Event;

    //public UnityEventArgType Response;

    protected abstract void OnEnable();


    protected abstract void OnDisable();


    public abstract void OnEventRaised();
           //Response.Invoke(Event.Argument);

}
