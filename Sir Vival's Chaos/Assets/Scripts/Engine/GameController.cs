using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    UIController uiCont;

    Barrack[] rax;

    [SerializeField]
    Settings setting;
    /// <summary>
    /// current time in game
    /// </summary>
    float time = 0;

    /// <summary>
    /// The current in-game time
    /// </summary>
    public float GameTime
    {
        get
        {
            return time;
        }
    }

	// Use this for initialization
	void Start () {
        uiCont = gameObject.AddComponent<UIController>();
        rax = GameObject.FindObjectsOfType<Barrack>();
	}
	
	// Update is called once per frame
	void Update () {

        //increment timer
        time += Time.deltaTime;

        UpdateBarrackCounters(Time.deltaTime);

	}

    /// <summary>
    /// Update the timer that tracks barrack spawns
    /// </summary>
    /// <param name="t">the time elapsed </param>
    void UpdateBarrackCounters(float t)
    {
        foreach(Barrack barrack in rax)
        {
            barrack.UpdateCounter(t);
        }
    }
}
