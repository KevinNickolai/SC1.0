using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a casted ability
/// </summary>
[CreateAssetMenu(fileName = "NewCastAbility", menuName = "Abilities/Ability/CastAbility", order = 4)]
public class CastAbility : CostedAbility {

    private void OnEnable()
    {
    }

    /// <summary>
    /// CastAbility Constructor
    /// </summary>
    /// <param name="cost">The mana cost of the Cast Ability</param>
    /// <param name="tt">The tooltip for the Cast Ability</param>
    //public CastAbility(int cost, Tooltip tt) : base(CostType.MANA,cost,tt) { }

    /// <summary>
    /// Activate the casted ability
    /// </summary>
    public override void Activate() { throw new System.NotImplementedException(); }
	
}
