﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains all defense aspects of an object
/// </summary>
[CreateAssetMenu(fileName = "NewDefense",menuName = "Stats/Defense/Defense", order = 1)]
public class Defense : ScriptableObject
{

    /// <summary>
    /// hitpoints object containing maxHP for an object
    /// </summary>
    [SerializeField]
    private Hitpoints hp;

    /// <summary>
    /// The armor of the defense aspect
    /// </summary>
    [SerializeField]
    private Armor armor;

    /// <summary>
    /// MaxHP for the object
    /// </summary>
    public int MaxHP
    {
        get
        {
            return hp.MaxHP;
        }
    }

    /// <summary>
    /// The armor value for the object
    /// </summary>
    public int Armor
    {
        get
        {
            return armor.ArmorValue;
        }
    }

    /// <summary>
    /// The armor type for the object
    /// </summary>
    public ArmorType ArmorType
    {
        get
        {
            return armor.ArmorType;
        }
    }
}