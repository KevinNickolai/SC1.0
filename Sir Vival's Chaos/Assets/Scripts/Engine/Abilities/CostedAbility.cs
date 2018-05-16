using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CostedAbility : ActivatedAbility {

    /// <summary>
    /// the cost of using the ability
    /// </summary>
    readonly int cost;
    
    /// <summary>
    /// The cost of using the ability
    /// </summary>
    public int Cost
    {
        get
        {
            return cost;
        }
    }

    /// <summary>
    /// Enumeration for the type of cost of an ability
    /// </summary>
    public enum CostType { GOLD, MANA }

    /// <summary>
    /// the cost type for this costed ability
    /// </summary>
    private readonly CostType costType;

    /// <summary>
    /// The type of cost for this ability
    /// </summary>
	public CostType TypeOfCost
    {
        get
        {
            return costType;
        }
    }

    /// <summary>
    /// CostedAbility Constructor
    /// </summary>
    /// <param name="ct">the CostType of the costed ability</param>
    /// <param name="c">the actual cost of the ability</param>
    /// <param name="tt">The tooltip for the ability</param>
    public CostedAbility(CostType ct, int c, Tooltip tt) : base(tt)
    {
        costType = ct;
        cost = c;
    }

}
