﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains all stat properties for a given object
/// </summary>
[CreateAssetMenu(fileName = "NewStats",menuName = "Stats/Stats", order = 1)]
public class Stats : ScriptableObject {

    /// <summary>
    /// the attack for the object
    /// </summary>
    [SerializeField]
    private Attack attack;

    /// <summary>
    /// the defense for the object
    /// </summary>
    [SerializeField]
    private Defense defense;

    /// <summary>
    /// The attack stats for the object
    /// </summary>
    public Attack Attack
    {
        get
        {
            return attack;
        }
    }

    /// <summary>
    /// The defense stats for the object
    /// </summary>
    public Defense Defense
    {
        get
        {
            return defense;
        }
    }
}