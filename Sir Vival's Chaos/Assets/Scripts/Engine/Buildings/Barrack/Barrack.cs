using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : LevelBuilding {
    public GameObject unit;

    private int spawnTimer = 40;

    /// <summary>
    /// Initialize Barracks features
    /// </summary>
    protected new void Start()
    {
        //we still want to initialize other features of the base classes
        base.Start();

        /**
        Quaternion rot = Quaternion.Euler(new Vector3(0, 270, 0));

        GameObject raxCounter = (GameObject)Instantiate(Resources.Load("Prefabs/Rax Counter"),
            gameObject.transform.position + new Vector3(0, 10, 0),
            gameObject.transform.rotation);

        raxCounter.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        raxCounter.transform.SetParent(gameObject.transform);
        raxCounter.transform.GetComponentInChildren<RaxCounter>().init();*/
    }

    public void Spawn()
    {
        GameObject unitClone = (GameObject)Instantiate(Resources.Load("Prefabs/unit", typeof(GameObject)),transform.position + new Vector3(0,30,0),transform.rotation);
    }
}
