using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaxCounter : MonoBehaviour {

    private float spawnTimer;

    private float spawnRate = 10.0f;

    Barrack rax;

    /// <summary>
    /// The text object that shows the current time
    /// </summary>
    Text timerText;

	// Use this for initialization
	void Start () {
        //get the barrack this RaxCounter is attached to
        rax = (gameObject.GetComponentInParent<Transform>()).gameObject.GetComponentInParent<Barrack>();

        //set the spawn timer initially to the spawn rate
        spawnTimer = spawnRate;

        timerText = gameObject.GetComponentInChildren<Text>();
    }

    /// <summary>
    /// Update the raxCounter's timer
    /// </summary>
    /// <param name="time">update the timer by this time</param>
    public void UpdateTimer(float time)
    {
        spawnTimer -= time;

        //timer is up
        if(spawnTimer <= 0)
        {
            //spawn the wave
            rax.SpawnWave();

            //reset timer
            spawnTimer = spawnRate;
        }
        
        timerText.text = ((int)spawnTimer).ToString();
    }

}
