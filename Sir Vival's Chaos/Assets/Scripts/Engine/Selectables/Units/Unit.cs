using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Selectable {

    /// <summary>
    /// The runtime set for the unit to add itself to
    /// </summary>
    [SerializeField]
    private UnitSet unitSet;

    public const string unit = "Prefabs/unit";

    protected Vector3 spawnPoint;

    /// <summary>
    /// The name of the unit
    /// </summary>
    private new string name; //< the new keyword distinguishes Building::name from Object::name, since that's not the intended inheiritance.

    /// <summary>
    /// The player that owns this unit
    /// </summary>
    private Player player;

    public Player Player
    {
        get
        {
            return player;
        }
    }

    private Ability[] abilities;

    public Ability[] Abilities
    {
        get
        {
            return abilities;
        }
    }

    protected void Start()
    {
        base.Start();
        unitSet.Add(this);
        name = gameObject.transform.name;
        spawnPoint = new Vector3(0, 30, 0);
    }

    protected virtual void OnMouseDown()
    {
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);
    }

    public static void Spawn(string prefabLoc, Vector3 pos, Quaternion rot)
    {
        GameObject unit = (GameObject)Resources.Load(prefabLoc, typeof(GameObject));

        if(unit != null)
        {
            Instantiate(unit, pos, rot);
        }
        else
        {
            Debug.Log("No prefab at location: " + prefabLoc);
        }
    }
}
