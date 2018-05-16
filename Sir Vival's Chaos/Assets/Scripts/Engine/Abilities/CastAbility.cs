using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a casted ability
/// </summary>
public class CastAbility : CostedAbility {

    /// <summary>
    /// CastAbility Constructor
    /// </summary>
    /// <param name="cost">The mana cost of the Cast Ability</param>
    /// <param name="tt">The tooltip for the Cast Ability</param>
    public CastAbility(int cost, Tooltip tt) : base(CostType.MANA,cost,tt) { }

    public override void Activate() { throw new System.NotImplementedException(); }
	
}
