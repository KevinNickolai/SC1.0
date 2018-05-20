using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing the attack aspect of an object
/// </summary>
[CreateAssetMenu(fileName = "NewAttack", menuName = "Stats/Attack/Attack", order = 1)]
public class Attack : ScriptableObject {
    [SerializeField]
    private Damage dmg;

    [SerializeField]
    private AttackSpeed atkSpd;

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

    
}
