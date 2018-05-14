using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ILevelable {

    /// <summary>
    /// The level of the upgrade
    /// </summary>
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
}