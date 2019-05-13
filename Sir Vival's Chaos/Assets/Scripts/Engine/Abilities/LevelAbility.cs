using UnityEngine;

/// <summary>
/// Class describing an ability that will level something up
/// </summary>
[CreateAssetMenu(fileName = "NewLevelAbility", menuName = "Abilities/Ability/LevelAbility", order = 1)]
public class LevelAbility : CostedAbility {


    protected override void OnEnable()
    {
        base.OnEnable();
        researching = false;
    }
    /// <summary>
    /// The ILevelable associated with this Leveling ability
    /// </summary>
    ILevelable levelable;

    Building building;

    public Building Building
    {
        get
        {
            return building;
        }
    }
    /// <summary>
    /// AbilityLevel Constructor
    /// </summary>
    /// <param name="cost">The cost associated with this Leveling ability</param>
    /// <param name="tt">The Tooltip for this ability</param>
    //public LevelAbility(int cost, Tooltip tt) : base(CostType.GOLD,cost,tt)

    /// <summary>
    /// the time to research the LevelAbility, before the level is applied, in seconds
    /// </summary>
    [SerializeField]
    private int researchTime = 0;

    private bool researching = false;

    public bool Researching
    {
        get
        {
            return researching;
        }
    }

    public int ResearchTime
    {
        get
        {
            return researchTime;
        }
    }

    /// <summary>
    /// Activate a level up ability
    /// </summary>
    public override void Activate()
    {
        if (building.Research(this))
        {
            researching = true;
            SetActivatable(false);
            UIController.GetInstance().Redraw();
        }
        //levelable.LevelUp();
    }

    private void OnResearchEnd()
    {
        researching = false;
        SetActivatable(true);
        UIController.GetInstance().RedrawAbilities();
    }

    public void CompleteResearch()
    {
        levelable.LevelUp();
        OnResearchEnd();
    }

    public override void SetLevelable(ILevelable b)
    {
        levelable = b;
    }

    public override void SetBuilding(Building b)
    {
        building = b;
    }

    public void EndResearch()
    {
        OnResearchEnd();
    }
}
