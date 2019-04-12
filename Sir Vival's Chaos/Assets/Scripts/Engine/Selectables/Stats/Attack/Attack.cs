﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing the attack aspect of an object
/// </summary>
[CreateAssetMenu(fileName = "NewAttack", menuName = "Stats/Attack/Attack", order = 1)]
public class Attack : ScriptableObject {

    /// <summary>
    /// Damage object for the attack
    /// </summary>
    [SerializeField]
    private Damage dmg;

    /// <summary>
    /// Attack speed object for the attack
    /// </summary>
    [SerializeField]
    private AttackSpeed atkSpd;

    /// <summary>
    /// The AttackUpgrade the Attack object uses
    /// </summary>
    [SerializeField]
    private AttackUpgrade upgrade;

    [SerializeField]
    private Race.AttackUpgradeTypes atkUpgr;

    /// <summary>
    /// The damage aspect of the attack
    /// </summary>
    public Damage Damage
    {
        get
        {
            return dmg;
        }
    }

    /// <summary>
    /// The attack speed aspect of an object
    /// </summary>
    public AttackSpeed AttackSpeed
    {
        get
        {
            return atkSpd;
        }
    }

    /// <summary>
    /// The attack upgrade type that the object uses
    /// </summary>
    public Race.AttackUpgradeTypes AttackUpgrade
    {
        get
        {
            return atkUpgr;
        }
    }
    
}
