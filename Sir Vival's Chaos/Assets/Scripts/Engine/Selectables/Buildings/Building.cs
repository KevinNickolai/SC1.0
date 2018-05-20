using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IDescribable, IAbilityUsable {
    /// <summary>
    /// The name of the building
    /// </summary>
    private new string name; //< the new keyword distinguishes Building::name from Object::name, since that's not the intended inheiritance.

    /// <summary>
    /// The player that owns this building
    /// </summary>
    private Player player;

    /// <summary>
    /// The stats for a building
    /// </summary>
    [SerializeField]
    private Stats buildingStats;

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
            return buildingStats.Attack.Damage.MinDamage;
        }
    }

    public int MaxDamage
    {
        get
        {
            return buildingStats.Attack.Damage.MaxDamage;
        }
    }

    public int Armor
    {
        get
        {
            return buildingStats.Defense.Armor;
        }
    }

    private AbilityList abilities;

    public AbilityList Abilities
    {
        get
        {
            return abilities;
        }
    }

    /// <summary>
    /// Set the Ability List for this building
    /// </summary>
    /// <param name="list">The initial AbilityList for this building</param>
    public void SetAbilityList(AbilityList list)
    {
        abilities = list;
    }

    /// <summary>
    /// Initialization of the building
    /// </summary>
    protected void Start()
    {
        //set building name
        name = gameObject.transform.name;

        //associate the player that owns this building; incomplete due to differences of multiple players.
        player = GameObject.FindObjectOfType<Player>();
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this Building
    /// </summary>
    protected void OnMouseDown()
    {
        //Display information for this Building
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);

        UIController.GetInstance().SetAbilityPanes(abilities);
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
