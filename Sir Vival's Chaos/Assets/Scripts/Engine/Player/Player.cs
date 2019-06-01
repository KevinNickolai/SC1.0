using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour {

    int income = 500;

    [SerializeField]
    private StringArgGameEventListener.StringArgUnityEvent GoldEvent;

    /// <summary>
    /// Test ScriptableObject Race
    /// </summary>
    [SerializeField]
    private Race race;

    /// <summary>
    /// The player's gold
    /// </summary>
    private int gold = 0;

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

        GameObject playerBuildingGroup = GameObject.Find("Player 3");

        //set all of the buildings for this player
        nexus = playerBuildingGroup.GetComponentInChildren<Nexus>();
        barracks = playerBuildingGroup.GetComponentsInChildren<Barrack>();
        towers = playerBuildingGroup.GetComponentsInChildren<Tower>();

        nexus.SetProperties(race, this);

        foreach(Tower t in towers)
        {
            t.SetProperties(race, this);
        }

        foreach(Barrack b in barracks)
        {
            b.SetProperties(race, this);
        }

        #region Set AbilityLists for all buildings

        //barracks[0].SetProperties((AbilityList)(AssetCopier.DeepCopy(race.BarrackAbilities)));

        //barracks[1].SetProperties(race.BarrackAbilities);
        //Set the nexus ability list, using the race's nexus abilities
        //nexus.SetAbilityList(race.GetNewNexusAbilities(nexus));

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

    public void GiveIncome()
    {
        GiveGold(income);
    }

    public void GiveGold(int amount)
    {
        gold += amount;
        GoldEvent.Invoke(gold.ToString());
        //UIController.GetInstance().UpdateGold(gold);
    }

    public void Pay(int cost)
    {
        gold -= cost;
        GoldEvent.Invoke(gold.ToString());
    }
}
