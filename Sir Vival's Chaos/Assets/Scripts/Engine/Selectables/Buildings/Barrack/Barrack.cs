using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : LevelBuilding {

    /// <summary>
    /// List of things to spawn in a wave
    /// </summary>
    private List<string> wave;

    /// <summary>
    /// The spawnpoints for this Barrack Object
    /// </summary>
    private SpawnPoints spawnPoints;

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
        wave.Add(Unit.unit);

        
        //wave.Add(Hero.hero);

        InitializeSpawnPoints();

        InitializeRaxCounter();
    }

    /// <summary>
    /// Initialize the spawn points for this barrack
    /// </summary>
    private void InitializeSpawnPoints()
    {
        List<Vector3> sp = new List<Vector3>();

        // x direction affects forward
        if(transform.forward.x != 0)
        {
            //use for spawn point addition where x is forward
        }
        //z direction affects forward
        else if(transform.forward.z != 0)
        {
            //use for spawn point addition where z is forward
        }

        sp.Add(new Vector3(transform.forward.x * 17.5f, 0, transform.forward.z * 17.5f));
        //create a spawnpoint, using the gameObject.transform.forward as the measure for a direction, to give a spawnpoint on the 
        //forward face of the barrack
        spawnPoints = new SpawnPoints(sp);
    }

    /// <summary>
    /// Instantiate a rax counter for the barrack
    /// </summary>
    private void InitializeRaxCounter()
    {
        //instantiate the prefab of a rax counter, spawned above the parent barrack and slightly tilted for better readability
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
            Unit.Spawn(unit, this.transform.position + spawnPoints.GetNextSpawnPoint(), gameObject.transform.rotation);
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

    /// <summary>
    /// Spawn a specific unit from the barrack
    /// </summary>
    /// <param name="loc">the path of the prefab of the unit</param>
    public void Spawn(string loc)
    {
        Unit.Spawn(loc, this.transform.position + new Vector3(0, 30, 0), this.transform.rotation);
    }
}
