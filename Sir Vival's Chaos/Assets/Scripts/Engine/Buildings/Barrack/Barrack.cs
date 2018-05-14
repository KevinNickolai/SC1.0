using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : LevelBuilding {

    /// <summary>
    /// List of things to spawn in a wave
    /// </summary>
    private List<string> wave;

    /// <summary>
    /// The timer for the barrack spawns associated with this barrack
    /// </summary>
    RaxCounter raxTimer;

    /// <summary>
    /// Initialize Barracks features
    /// </summary>
    protected new void Start()
    {
        //we still want to initialize other features of the base classes
        base.Start();

        wave = new List<string>();

        wave.Add(Unit.unit);

        //wave.Add(Hero.hero);
        
        //instantiate a rax counter for the barrack
        GameObject raxCounter = (GameObject)Instantiate(Resources.Load("Prefabs/Rax Counter"),
            gameObject.transform.position + new Vector3(0, 25, 0),
            Quaternion.Euler(new Vector3(15, 0, 0)),
            gameObject.transform);

        raxTimer = raxCounter.GetComponentInChildren<RaxCounter>();
    }

    /// <summary>
    /// Spawn a wave from this barrack
    /// </summary>
    public void SpawnWave()
    {
        foreach(string unit in wave)
        {
            Unit.Spawn(unit,this.transform.position + new Vector3(0,30,0), this.transform.rotation);
        }
    }

    /// <summary>
    /// Update the counter for this barrack
    /// </summary>
    /// <param name="time">the time to increment the counter by</param>
    public void UpdateCounter(float time)
    {
        raxTimer.UpdateTimer(time);
    }
}
