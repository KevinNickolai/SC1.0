using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a Levelable building
/// </summary>
public abstract class LevelBuilding : Building, ILevelableObject{

    //TODO: Max level readonly(?)

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
    public void LevelUp()
    {
        ++this.level;
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this LevelBuilding
    /// </summary>
    private void OnMouseDown()
    {
        //Display the information for this LevelBuilding
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);

        UIController.GetInstance().SetAbilityPanes(Abilities);
    }
}