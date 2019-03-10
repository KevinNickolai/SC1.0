using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Abilities/Ability/SpawnAbility", order = 1)]
public class SpawnAbility : CostedAbility {

    /// <summary>
    /// The barrack to spawn from
    /// </summary>
    Barrack barrack;

    /// <summary>
    /// The prefab of the unit to spawn
    /// </summary>
    GameObject unitLoc;

    /// <summary>
    /// SpawnAbility Constructor
    /// </summary>
    /// <param name="b">The barrack associated with this Spawn ability</param>
    /// <param name="loc">The path to the prefab of the unit to spawn</param>
    /// <param name="cost">The cost associated with spawning the unit from this barrack</param>
    /// <param name="tt">The tooltip for this ability</param>
    //public SpawnAbility(Barrack b, string loc, int cost, Tooltip tt) : base(CostType.GOLD,cost,tt)
    
    /// <summary>
    /// Activate the spawn of the unit
    /// </summary>
    public override void Activate()
    {
        barrack.Spawn(unitLoc);
    }

    /// <summary>
    /// Set the building of this spawning ability to a barrack building
    /// </summary>
    /// <param name="b">the building to set</param>
    public override void SetBuilding(Building b)
    {
        barrack = (Barrack)b;
    }
}
