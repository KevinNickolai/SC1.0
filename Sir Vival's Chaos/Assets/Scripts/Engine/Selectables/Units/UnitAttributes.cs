using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitAttributes : ScriptableObject {

    [Range(0,50000)]
    public int Hitpoints;
    public int Armor;

    public int MinDamage;
    public int MaxDamage;
}