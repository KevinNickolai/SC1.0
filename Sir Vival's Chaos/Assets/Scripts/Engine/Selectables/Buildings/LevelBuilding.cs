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

    /// <summary>
    /// The maximum level the building can go to
    /// </summary>
    private int maxLevel = 1;

    /// <summary>
    /// Set the maximum level of the LevelBuilding
    /// </summary>
    /// <param name="max"></param>
    protected void SetMaxLevel(int max)
    {
        maxLevel = max;
    }

    public override void SetProperties(Race race, Player p)
    {
        base.SetProperties(race, p);
    }

    /// <summary>
    /// Level the building up by one if it's less than the maximum level
    /// </summary>
    public void LevelUp()
    {
        if(level < maxLevel)
            ++this.level;
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this LevelBuilding
    /// </summary>
    protected override void OnMouseDown()
    {
        //Display the information for this LevelBuilding
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);

        UIController.GetInstance().SetAbilityPanes(Abilities);
    }
}