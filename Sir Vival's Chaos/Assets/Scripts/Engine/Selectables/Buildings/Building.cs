using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Selectable, IAbilityUsable {

    /// <summary>
    /// The building set that this building is associated with
    /// </summary>
    [SerializeField]
    private BuildingSet buildingSet;
    /// <summary>
    /// The player that owns this building
    /// </summary>
    private Player player;

    public Player Player
    {
        get
        {
            return player;
        }
    }

    [SerializeField]
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
        buildingSet.Add(this);

        //associate the player that owns this building; incomplete due to differences of multiple players.
        player = GameObject.FindObjectOfType<Player>();
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this Building
    /// </summary>
    protected virtual void OnMouseDown()
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
