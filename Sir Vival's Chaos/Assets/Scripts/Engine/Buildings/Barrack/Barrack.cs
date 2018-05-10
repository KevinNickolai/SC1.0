using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : LevelBuilding {

    private List<string> wave;

    private int spawnTimer = 40;

    /// <summary>
    /// Initialize Barracks features
    /// </summary>
    protected new void Start()
    {
        //we still want to initialize other features of the base classes
        base.Start();

        wave = new List<string>();

        wave.Add(Unit.unit);

        wave.Add(Hero.hero);
        /**
        Quaternion rot = Quaternion.Euler(new Vector3(0, 270, 0));

        GameObject raxCounter = (GameObject)Instantiate(Resources.Load("Prefabs/Rax Counter"),
            gameObject.transform.position + new Vector3(0, 10, 0),
            gameObject.transform.rotation);

        raxCounter.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        raxCounter.transform.SetParent(gameObject.transform);
        raxCounter.transform.GetComponentInChildren<RaxCounter>().init();*/
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
}
