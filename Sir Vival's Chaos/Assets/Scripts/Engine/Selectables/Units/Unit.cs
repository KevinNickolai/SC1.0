using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Selectable {

    /// <summary>
    /// The runtime set for the unit to add itself to
    /// </summary>
    [SerializeField]
    private UnitSet unitSet;

    protected Vector3 spawnPoint;

    /// <summary>
    /// The name of the unit
    /// </summary>
    private new string name; //< the new keyword distinguishes Unit::name from Object::name, since that's not the intended inheiritance.

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

    /// <summary>
    /// Spawn a unit at a certain position/rotation, owned by a specific player
    /// </summary>
    /// <param name="unitObj">The GameObject unit to spawn</param>
    /// <param name="pos">The position to spawn the prefab at</param>
    /// <param name="rot">The rotation of the prefab being spawned</param>
    /// <param name="p">The player that owns the spawned prefab</param>
    public static void Spawn(GameObject unitObj, Vector3 pos, Quaternion rot, Player p)
    {
        if(unitObj != null)
        {
            GameObject instancedUnit = Instantiate(unitObj, pos, rot);
            instancedUnit.GetComponent<Unit>().SetPlayer(p);
        }
        else
        {
            Debug.LogError("Attempted to spawn null unit.");
        }
    }
}
