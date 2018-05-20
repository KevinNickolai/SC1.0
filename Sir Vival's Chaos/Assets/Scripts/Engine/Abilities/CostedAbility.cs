using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing an ability with a cost associated to it
/// </summary>
public abstract class CostedAbility : ActivatedAbility {

    /// <summary>
    /// the cost of using the ability
    /// </summary>
    [SerializeField]
    private int cost;
    
    /// <summary>
    /// Set the cost type for the CostedAbility
    /// </summary>
    /// <param name="ct">The CostType for the Ability</param>
    protected void SetCostType(CostType ct)
    {
        costType = ct;
    }

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
    [SerializeField]
    private CostType costType;

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

}
