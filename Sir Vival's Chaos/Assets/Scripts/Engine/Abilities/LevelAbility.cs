using UnityEngine;

/// <summary>
/// Class describing an ability that will level something up
/// </summary>
[CreateAssetMenu(fileName = "NewLevelAbility", menuName = "Abilities/Ability/LevelAbility", order = 1)]
public class LevelAbility : CostedAbility {

    /// <summary>
    /// The ILevelable associated with this Leveling ability
    /// </summary>
    ILevelable levelable;

    /// <summary>
    /// AbilityLevel Constructor
    /// </summary>
    /// <param name="cost">The cost associated with this Leveling ability</param>
    /// <param name="tt">The Tooltip for this ability</param>
    //public LevelAbility(int cost, Tooltip tt) : base(CostType.GOLD,cost,tt)


    /// <summary>
    /// Activate a level up ability
    /// </summary>
    public override void Activate()
    {
        levelable.LevelUp();
        UIController.GetInstance().Redraw();
    }

    public override void SetLevelable(ILevelable b)
    {
        levelable = b;
    }

}
