using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Upgrade : ScriptableObject, ILevelable {

    /// <summary>
    /// The level of the upgrade
    /// </summary>
    [SerializeField]
    int level = 0; //<note that upgrade levels start at 0; no upgrades are initially given

    /// <summary>
    /// The level of the upgrade
    /// </summary>
    public int Level
    {
        get
        {
            return level;
        }
    }

    public void LevelUp()
    {
        ++level;
    }

    public void OnEnable()
    {
        level = 0;
    }
}