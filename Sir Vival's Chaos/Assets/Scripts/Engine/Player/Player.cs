using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// Test ScriptableObject Race
    /// </summary>
    [SerializeField]
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

        nexus.SetAbilityList(race.NexusAbilities);

        #region Set AbilityLists for all buildings

        barracks[0].SetAbilityList((AbilityList)(AssetCopier.DeepCopy(race.BarrackAbilities)));

        barracks[1].SetAbilityList(race.BarrackAbilities);
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
