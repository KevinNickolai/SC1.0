using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class defining hitpoint data for objects.
/// </summary>
[CreateAssetMenu(fileName = "NewHitpoints", menuName = "Stats/Defense/Hitpoints", order = 1)]
public class Hitpoints : ScriptableObject {

    /// <summary>
    /// MaxHP IntReference for the object
    /// </summary>
    [SerializeField]
    private IntReference maxHP;

    /// <summary>
    /// Get the MaxHP for the object
    /// </summary>
    public int MaxHP
    {
        get
        {
            return maxHP.Value;
        }
    }
}
