using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing an ability that will level something up
/// </summary>
[CreateAssetMenu(fileName = "NewLevelAbility", menuName = "Abilities/Ability/LevelAbility", order = 1)]
public class LevelAbility : CostedAbility {

    /// <summary>
    /// The building associated with this Leveling ability
    /// </summary>
    LevelBuilding lb;

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
        lb.LevelUp();
    }

    public override void SetLevelable(ILevelable b)
    {
        lb = (LevelBuilding)b;
    }

}
