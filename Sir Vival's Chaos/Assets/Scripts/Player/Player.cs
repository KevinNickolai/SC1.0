using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// The player's race
    /// </summary>
    private Race race;

    /// <summary>
    /// The player's gold
    /// </summary>
    private int gold;

    /// <summary>
    /// The player's gold
    /// </summary>
    public int Gold
    {
        get
        {
            return gold;
        }
    }

    /// <summary>
    /// The player's race
    /// </summary>
    public Race Race
    {
        get
        {
            return race;
        }
    }

    private Nexus nexus;
    private Tower[] towers;
    private Barrack[] barracks;

    public void Start()
    {
        race = new Human();

        GameObject playerBuildingGroup = GameObject.Find("Player 3");

        //set all of the buildings for this player
        nexus = playerBuildingGroup.GetComponentInChildren<Nexus>();
        barracks = playerBuildingGroup.GetComponentsInChildren<Barrack>();
        towers = playerBuildingGroup.GetComponentsInChildren<Tower>();

        #region Set AbilityLists for all buildings

        //Set the nexus ability list, using the race's nexus abilities
        nexus.SetAbilityList(race.GetNewNexusAbilities(nexus));

        foreach(Barrack rax in barracks)
        {
            rax.SetAbilityList(race.GetNewBarrackAbilities(rax));
        }
        foreach(Tower tower in towers)
        {
            tower.SetAbilityList(race.GetNewTowerAbilities());           
        }

        #endregion
        //add Player input controls to the player
        gameObject.AddComponent<InputControls>();
    }
    
}
