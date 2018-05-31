using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "NewTypeMatchup", menuName = "Stats/TypeMatchup")]
public class DmgArmorTypeMatchup : ScriptableObject
{
    [SerializeField]
    List<ArmorType> at = new List<ArmorType>(5);

    [SerializeField]
    List<DamageType> dt = new List<DamageType>(5);

    [SerializeField]
    List<List<int>> matchup;
}
