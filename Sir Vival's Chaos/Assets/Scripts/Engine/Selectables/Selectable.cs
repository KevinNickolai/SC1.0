﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class defining a selectable object and its stats
/// </summary>
public abstract class Selectable : MonoBehaviour, IDescribable {

    /// <summary>
    /// Underlying stats for the selectable
    /// </summary>
    [SerializeField]
    private Stats stats;

    private HPTrackerUI hpUI;

    public void Start()
    {
        hpUI = new HPTrackerUI(gameObject, stats.Defense.MaxHPRef);
        
    }

    /// <summary>
    /// The name of the selectable object
    /// </summary>
    public string Name
    {
        get
        {
            return stats.Name;
        }
    }

    /// <summary>
    /// the minimum damage of the selectable object
    /// </summary>
    public int MinDamage
    {
        get
        {
            return stats.Attack.Damage.MinDamage;
        }
    }

    /// <summary>
    /// max damage of the selectable object
    /// </summary>
    public int MaxDamage
    {
        get
        {
            return stats.Attack.Damage.MaxDamage;
        }
    }

    /// <summary>
    /// armor for the selectable object
    /// </summary>
    public int Armor
    {
        get
        {
            return stats.Defense.Armor;
        }
    }

    /// <summary>
    /// ArmorType of the selectable object
    /// </summary>
    public ArmorType ArmorType
    {
        get
        {
            return stats.Defense.ArmorType;
        }
    }

    /// <summary>
    /// DamateType of the selectable object
    /// </summary>
    public DamageType DamageType
    {
        get
        {
            return stats.Attack.Damage.DamageType;
        }
    }

}
