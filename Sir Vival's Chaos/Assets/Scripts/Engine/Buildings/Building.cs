using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IDescribable {
    /// <summary>
    /// The name of the building
    /// </summary>
    private new string name; //< the new keyword distinguishes Building::name from Object::name, since that's not the intended inheiritance.

    /// <summary>
    /// The player that owns this building
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
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this Building
    /// </summary>
    protected void OnMouseDown()
    {
        //Display information for this Building
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);
    }

    /// <summary>
    /// When the mouse hovers over the collider of the building, display the outline
    /// </summary>
    protected void OnMouseEnter()
    {
    }

    /// <summary>
    /// When the mouse stops hovering over the collider of the building, remove the outline
    /// </summary>
    protected void OnMouseExit()
    {
        
    }
}
