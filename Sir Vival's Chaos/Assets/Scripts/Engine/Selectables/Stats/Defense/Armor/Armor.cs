using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing Armor data for an object
/// </summary>
[CreateAssetMenu(fileName = "NewArmor",menuName = "Stats/Defense/Armor/Armor", order = 1)]
public class Armor : ScriptableObject {

    /// <summary>
    /// The IntReference for the armor value
    /// </summary>
    [SerializeField]
    private IntReference armor;

    /// <summary>
    /// The ArmorType of the armor
    /// </summary>
    [SerializeField]
    private ArmorType armorType;

    /// <summary>
    /// The value of the armor
    /// </summary>
    public int ArmorValue
    {
        get
        {
            return armor.Value;
        }
    }

    /// <summary>
    /// The type of armor for the object
    /// </summary>
    public ArmorType ArmorType
    {
        get
        {
            return armorType;
        }
    }
}
