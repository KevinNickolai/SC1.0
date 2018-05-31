﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// Test ScriptableObject Race
    /// </summary>
    [SerializeField]
    private TestRace r;

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
    public TestRace Race
    {
        get
        {
            return r;
        }
    }

    //Potentially add runtime sets for buildings/units here
    //since a player would track their ownership of those things.
    private BuildingSet buildingSet;

    private Nexus nexus;
    private Tower[] towers;
    private Barrack[] barracks;

    public void Start()
    {
        //race = new Human();

        GameObject playerBuildingGroup = GameObject.Find("Player 3");

        //set all of the buildings for this player
        nexus = playerBuildingGroup.GetComponentInChildren<Nexus>();
        barracks = playerBuildingGroup.GetComponentsInChildren<Barrack>();
        towers = playerBuildingGroup.GetComponentsInChildren<Tower>();

        nexus.SetAbilityList(r.NexusAbilities);

        #region Set AbilityLists for all buildings

        barracks[0].SetAbilityList((AbilityList)(AssetCopier.DeepCopy(r.BarrackAbilities)));

        barracks[1].SetAbilityList(r.BarrackAbilities);
        //Set the nexus ability list, using the race's nexus abilities
//        nexus.SetAbilityList(race.GetNewNexusAbilities(nexus));

        //foreach(Barrack rax in barracks)
        //{
        //    rax.SetAbilityList(race.GetNewBarrackAbilities(rax));
        //}
        //foreach(Tower tower in towers)
        //{
        //    tower.SetAbilityList(race.GetNewTowerAbilities());           
        //}

        #endregion

        //add Player input controls to the camera
        Camera.main.gameObject.AddComponent<InputControls>();
    }
    
}