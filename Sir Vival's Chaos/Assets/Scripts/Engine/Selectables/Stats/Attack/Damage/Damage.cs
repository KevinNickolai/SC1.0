using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing Damage data for an object
/// </summary>
[CreateAssetMenu(fileName = "NewDamage",menuName = "Stats/Attack/Damage/Damage", order = 1)]
public class Damage : ScriptableObject {

    /// <summary>
    /// Minimum damage for the object
    /// </summary>
    [SerializeField]
    private IntReference minDmg;

    /// <summary>
    /// Maximum damage for the object
    /// </summary>
    [SerializeField]
    private IntReference maxDmg;

    /// <summary>
    /// DamageType for the object
    /// </summary>
    [SerializeField]
    private DamageType damageType;

    /// <summary>
    /// The maximum damage for this Damage object
    /// </summary>
    public int MaxDamage
    {
        get
        {
            return maxDmg.Value;
        }
    }

    /// <summary>
    /// The minimum damage for this Damage object
    /// </summary>
    public int MinDamage
    {
        get
        {
            return minDmg.Value;
        }
    }

    /// <summary>
    /// The DamageType of this damage
    /// </summary>
    public DamageType DamageType
    {
        get
        {
            return damageType;
        }
    }
}
