using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Abilities/Ability/RepairAbility", order = 1)]
public class RepairAbility : ActivatedAbility {

    /// <summary>
    /// The barrack this repair ability is attached to
    /// </summary>
    Barrack barrack;

    /// <summary>
    /// RepairAbility Constructor
    /// </summary>
    /// <param name="tt">tooltip for the RepairAbility</param>
    //public RepairAbility(Tooltip tt) : base(tt) { }

    /// <summary>
    /// Activate the Repair Ability
    /// </summary>
    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Set the barrack for the Repair Ability
    /// </summary>
    /// <param name="b">The Barrack for the RepairAbility</param>
    public override void SetBuilding(Building b)
    {
        barrack = (Barrack)b;
    }
}
