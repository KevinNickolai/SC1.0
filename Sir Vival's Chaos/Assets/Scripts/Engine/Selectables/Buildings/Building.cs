using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Selectable, IResearcher {

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

        //buildingSet.Add(this);

        highlight = gameObject.GetComponentInChildren<Highlight>();
        highlight.HideHighlight();
        researcher = new Researcher();
    }

    private void Update()
    {
        if (researcher.Researching)
        {
            AddTime(Time.deltaTime);
        }
    }
    public Researcher.ResearchQueue Queue
    {
        get
        {
            return researcher.Queue;
        }
    }

    public void AddTime(float t)
    {
        researcher.AddTime(t);
    }

    public float Timer
    {
        get
        {
            return researcher.Timer;
        }
    }

    private Researcher researcher;

    /// <summary>
    /// Cancel the research at a specific position in the queue of research for the building
    /// </summary>
    /// <param name="relativePosition">the position of the object in the queue</param>
    /// <returns>true if the research was properly cancelled</returns>
    public bool CancelResearch(int relativePosition)
    {
        return researcher.CancelResearch(relativePosition);
    }

    /// <summary>
    /// Research a LevelAbility on the building
    /// </summary>
    /// <param name="toResearch">the LevelAbility that is being attempted to research</param>
    /// <return>true if the researcher is able to research the LevelAbility at this time</return>
    public bool Research(LevelAbility toResearch)
    {
        return researcher.Research(toResearch);
    }

    /// <summary>
    /// Flag indicating if the building is currently researching
    /// </summary>
    public bool Researching
    {
        get
        {
            return researcher.Researching;
        }
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
