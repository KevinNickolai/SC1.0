using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    UIController uiCont;

    /// <summary>
    /// temporary flag to only spawn once
    /// </summary>
    bool spawn = false;

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
	}
	
	// Update is called once per frame
	void Update () {

        //increment timer
        time += Time.deltaTime;

        //temporary spawning code
        if(time > 1 && !spawn)
        {
            spawn = true;
            Barrack[] rax = GameObject.FindObjectsOfType<Barrack>();

            for(int i = 0; i < rax.Length; ++i)
            {
                rax[i].SpawnWave();
            }
        }
	}

}
