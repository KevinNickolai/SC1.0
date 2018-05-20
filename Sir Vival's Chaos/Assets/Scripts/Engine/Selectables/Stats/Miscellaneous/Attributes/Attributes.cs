using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the data for attributes for a hero unit
/// </summary>
public class Attributes : ScriptableObject {

    /// <summary>
    /// strength of the unit with attributes
    /// </summary>
    [SerializeField]
    private IntReference strength;

    /// <summary>
    /// agility of unit with attributes
    /// </summary>
    [SerializeField]
    private IntReference agility;

    /// <summary>
    /// intelligence of the unit with attributes
    /// </summary>
    [SerializeField]
    private IntReference intelligence;

    /// <summary>
    /// The strength of the Unit with attributes
    /// </summary>
    public int Strength
    {
        get
        {
            return strength.Value;
        }
    }

    /// <summary>
    /// The agility of the Unit with attributes
    /// </summary>
    public int Agility
    {
        get
        {
            return agility.Value;
        }
    }

    /// <summary>
    /// The intelligence of the Unit with attributes
    /// </summary>
    public int Intelligence
    {
        get
        {
            return intelligence.Value;
        }
    }
}
