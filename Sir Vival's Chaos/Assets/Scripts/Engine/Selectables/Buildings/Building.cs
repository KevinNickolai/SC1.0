using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Selectable, IAbilityUsable {

    private Highlight highlight;

    /// <summary>
    /// The building set that this building is associated with
    /// </summary>
    [SerializeField]
    private BuildingSet buildingSet;

    /// <summary>
    /// The list of ability for the building
    /// </summary>
    [SerializeField]
    protected AbilityList abilities;

    /// <summary>
    /// The list of abilities for the building
    /// </summary>
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
    /// <param name="race">The race, with information on the properties for the building</param>
    public virtual void SetProperties(Race race, Player p)
    {
        SetPlayer(p);
    }

    /// <summary>
    /// Initialization of the building
    /// </summary>
    protected void Start()
    {
        base.Start();

        buildingSet.Add(this);

        highlight = gameObject.GetComponentInChildren<Highlight>();
        highlight.HideHighlight();
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
        highlight.ShowHighlight();
    }

    /// <summary>
    /// When the mouse stops hovering over the collider of the building, remove the outline
    /// </summary>
    protected void OnMouseExit()
    {
        highlight.HideHighlight();
    }
}
