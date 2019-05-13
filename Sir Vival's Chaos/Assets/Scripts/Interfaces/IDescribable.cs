using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that describes a describable object
/// 
/// Describable objects are anything with a name, damage, and armor
/// Describable objects also require a player to reference for upgrades
/// which may modify base armor and damage
/// </summary>
public interface IDescribable {

    string Name { get; }

    Player Player { get; }

    int MinDamage { get; }
    int MaxDamage { get; }

    int Armor { get; }

    ArmorType ArmorType { get; }
    DamageType DamageType { get; }

    Race.AttackUpgradeTypes AttackUpgradeType { get; }
    Race.DefenseUpgradeTypes DefenseUpgradeType { get; }
}
