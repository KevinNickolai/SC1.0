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

    /// <summary>
    /// The current time elapsed, in seconds, of the building's current research
    /// </summary>
    public float Timer
    {
        get
        {
            return researcher.Timer;
        }
    }

    /// <summary>
    /// The building's Researcher object
    /// </summary>
    private Researcher researcher;

    /// <summary>
    /// Cancel the research at a specific position in the queue of research for the building
    /// </summary>
    /// <param name="relativePosition">the position of the object in the queue</param>
    /// <returns>true if the research was properly cancelled</returns>
    public bool CancelResearch(int relativePosition, LevelAbility ability)
    {
        bool cancelled = researcher.CancelResearch(relativePosition);

        if (cancelled)
        {
            this.Player.GiveGold((int)System.Math.Floor(ability.Cost * .75));
        }

        return cancelled;
    }

    /// <summary>
    /// Research a LevelAbility on the building
    /// </summary>
    /// <param name="toResearch">the LevelAbility that is being attempted to research</param>
    /// <return>true if the researcher is able to research the LevelAbility at this time</return>
    public bool Research(LevelAbility toResearch)
    {
        bool startedResearch = false;
        if (CanPay(toResearch.Cost, toResearch.TypeOfCost))
        {
            startedResearch = researcher.Research(toResearch);

            if (startedResearch)
            {
                Pay(toResearch.Cost, toResearch.TypeOfCost);
            }
        }
        else
        {
            UIController.GetInstance().DisplayMessage("Not enough gold");
        }
        return startedResearch;
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

    private void Pay(int cost, CostedAbility.CostType type)
    {
        switch (type)
        {
            case CostedAbility.CostType.GOLD:
                this.Player.Pay(cost);
                break;

            case CostedAbility.CostType.MANA:
                throw new System.NotImplementedException("Buildings cannot pay manacosts yet.");
                break;

            default:
                throw new System.NotImplementedException("Cost type '" + type + "' not implemented yet.");
        }
    }

    private bool CanPay(int cost, CostedAbility.CostType type)
    {
        switch (type)
        {
            case CostedAbility.CostType.GOLD:
                if(this.Player.Gold >= cost)
                {
                    return true;
                }
                break;

            case CostedAbility.CostType.MANA:
                throw new System.NotImplementedException("Mana Not implemented yet.");
                break;

            default:
                throw new System.NotImplementedException("Cost Type '" + type + "' not implemented.");
        }

        return false;
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