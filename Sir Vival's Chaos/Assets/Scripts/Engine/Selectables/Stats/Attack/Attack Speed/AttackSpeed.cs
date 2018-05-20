using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing the attack speed of an object
/// </summary>
[CreateAssetMenu(fileName = "NewAttackSpeed", menuName = "Stats/Attack/AttackSpeed", order = 1)]
public class AttackSpeed : ScriptableObject {

    /// <summary>
    /// The attack speed for the object
    /// </summary>
    [SerializeField]
    private FloatReference atkSpd;

    /// <summary>
    /// The attack speed for the object
    /// </summary>
    public float AttackSpd
    {
        get
        {
            return atkSpd.Value;
        }
    }

}
