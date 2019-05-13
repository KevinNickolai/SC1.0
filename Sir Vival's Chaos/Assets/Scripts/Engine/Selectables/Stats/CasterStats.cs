using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A stats object with added properties for a spell caster
/// </summary>
[CreateAssetMenu(fileName = "NewCasterStats", menuName = "Stats/CasterStats", order = 1)]
public class CasterStats : Stats {

    [SerializeField]
    private Mana mana;

    public Mana Mana
    {
        get
        {
            return mana;
        }
    }

}
