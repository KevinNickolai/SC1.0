using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Upgrade : ScriptableObject, ILevelable {

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

    //The race that the upgrade belongs to
    [SerializeField][ReadOnly]
    private Race race;

    public void SetRace(Race r)
    {
        race = r;
    }

    /// <summary>
    /// List of the Stats objects that are using the upgrade
    /// </summary>
    protected List<Stats> affectedByUpgrade;

    public void AddStatsToUpgrade(Stats stat)
    {
        if (!affectedByUpgrade.Contains(stat))
        {
            affectedByUpgrade.Add(stat);
        }
    }

    public void RemoveFromUpgrade(Stats stat)
    {
        affectedByUpgrade.Remove(stat);
    }
}