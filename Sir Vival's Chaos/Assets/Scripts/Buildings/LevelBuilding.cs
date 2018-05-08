﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilding : Building {

    /// <summary>
    /// The current level of the building
    /// </summary>
    private int level = 1;

    /// <summary>
    /// The current level of the building
    /// </summary>
    public int Level
    {
        get
        {
            return level;
        }
    }

    public LevelBuilding()
    {

    }

    /// <summary>
    /// Level the building up by one
    /// </summary>
    protected void LevelUp()
    {
        ++this.level;
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this LevelBuilding
    /// </summary>
    protected void OnMouseDown()
    {
        //Display the information for this LevelBuilding
        GameObject.FindObjectOfType<UIController>().DisplayLevelBuildingInfo(this);
    }
}