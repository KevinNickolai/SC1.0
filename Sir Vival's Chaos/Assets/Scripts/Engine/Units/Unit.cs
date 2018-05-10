using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IDescribable {

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

    private int minDmg, maxDmg, armor;

    public Player Player
    {
        get
        {
            return player;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public int MinDamage
    {
        get
        {
            return minDmg;
        }
    }

    public int MaxDamage
    {
        get
        {
            return maxDmg;
        }
    }

    public int Armor
    {
        get
        {
            return armor;
        }
    }

    protected void Start()
    {
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
