﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing a playable race and its properties in the game
/// </summary>
public class Race : ScriptableObject {

    /// <summary>
    /// The name of the race
    /// </summary>
    [SerializeField]
    private new StringReference name;

    /// <summary>
    /// The name of the race
    /// </summary>
    public string Name
    {
        get
        {
            return name.Value;
        }
    }

    #region Upgrades

    public enum AttackUpgradeTypes { Melee, Gate, Mage }

    public AttackUpgrade GetAttackUpgrade(AttackUpgradeTypes atkUpgrT)
    {
        switch (atkUpgrT)
        {
            case AttackUpgradeTypes.Melee:
                return meleeUpgr;
            case AttackUpgradeTypes.Mage:
                return mageUpgr;
            case AttackUpgradeTypes.Gate:
                return gateUpgr;

            default:
                Debug.LogError("Attack Upgrade Type missing from selection of Race's retrieval of a specifc attack upgrade type");
                return meleeUpgr;
        }
    }

    /// <summary>
    /// The melee upgrade for the race
    /// </summary>
    [SerializeField]
    private AttackUpgrade meleeUpgr;

    /// <summary>
    /// The range upgrade for the race
    /// </summary>
    [SerializeField]
    private AttackUpgrade gateUpgr;

    /// <summary>
    /// The mage upgrade for the race
    /// </summary>
    [SerializeField]
    private MageUpgrade mageUpgr;

    /// <summary>
    /// The armor upgrade for the race
    /// </summary>
    [SerializeField]
    private DefenseUpgrade armorUpgr;

    /// <summary>
    /// The fort upgrade for the race
    /// </summary>
    [SerializeField]
    private DefenseUpgrade fortUpgr;

    /// <summary>
    /// Auxiliary upgrades for the race
    /// </summary>
    [SerializeField]
    private AuxUpgrade[] auxUpgrs;

    public AttackUpgrade MeleeUpgrade
    {
        get
        {
            return meleeUpgr;
        }
    }

    public AttackUpgrade GateUpgrade
    {
        get
        {
            return gateUpgr;
        }
    }

    public MageUpgrade MageUpgrade
    {
        get
        {
            return mageUpgr;
        }
    }

    public AuxUpgrade[] AuxiliaryUpgrades
    {
        get
        {
            return auxUpgrs;
        }
    }

    public DefenseUpgrade ArmorUpgrade
    {
        get
        {
            return armorUpgr;
        }
    }

    public DefenseUpgrade FortUpgrade
    {
        get
        {
            return fortUpgr;
        }
    }
    #endregion

    #region Building AbilityLists
    /// <summary>
    /// race nexus abilities
    /// </summary>
    [SerializeField]
    private AbilityList nexusAbilities;

    /// <summary>
    /// race barrack abilities
    /// </summary>
    [SerializeField]
    private AbilityList barrackAbilities;

    /// <summary>
    /// race tower abilities
    /// </summary>
    [SerializeField]
    private AbilityList towerAbilities;

    /// <summary>
    /// The nexus abilities for the race
    /// </summary>
    public AbilityList NexusAbilities
    {
        get
        {
            return nexusAbilities;
        }
    }

    /// <summary>
    /// The barrack abilities for the race
    /// </summary>
    public AbilityList BarrackAbilities
    {
        get
        {
            return barrackAbilities;
        }
    }

    /// <summary>
    /// The tower abilities for the race
    /// </summary>
    public AbilityList TowerAbilities
    {
        get
        {
            return towerAbilities;
        }
    }
    #endregion

    #region Building Stats

    [SerializeField]
    private Stats nexusStats;

    [SerializeField]
    private Stats barrackStats;

    [SerializeField]
    private Stats towerStats;

    #endregion

    #region Units

    //[SerializeField]
    //private Stats meleeUnit;

    [SerializeField]
    private Stats rangeUnit;

    [SerializeField]
    private Stats siegeUnit;

    [SerializeField]
    private Stats airUnit;

    [SerializeField]
    private Stats artilleryUnit;


    [SerializeField]
    private GameObject meleeUnit;

    public GameObject MeleeUnit
    {
        get
        {
            return meleeUnit;
        }
    }
    #endregion

    /// <summary>
    /// Enumeration of different factions a race can be a part of
    /// </summary>
    public enum RaceFaction { Alliance }

    /// <summary>
    /// the faction this race is a part of
    /// </summary>
    [SerializeField]
    private readonly RaceFaction faction;
}

#region race code
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class Race : ScriptableObject, IUpgradable, IAbilityContainable
//{

//    /**
// * Implement baseline Tower/Nexus/Barrack abilities lists for derived classes to use as a structure
// * 
// * either have protected Ability[] function() for editing the ability array itself
// * OR 
// * implement ways to modify an ability in an ability array or ability list that allows for 
// */

//    /// <summary>
//    /// The name of the race
//    /// </summary>
//    private readonly string name;

//    [SerializeField]
//    private MageUpgrade mageUpgr;

//    [SerializeField]
//    private GateUpgrade gateUpgr;

//    [SerializeField]
//    private MeleeUpgrade meleeUpgr;

//    [SerializeField]
//    private DefenseUpgrade armorUpgr;

//    [SerializeField]
//    private AuxUpgrade[] auxUpgrs;

//    /// <summary>
//    /// Enumeration of different factions a race can be a part of
//    /// </summary>
//    public enum RaceFaction { Alliance }

//    /// <summary>
//    /// the faction this race is a part of
//    /// </summary>
//    private readonly RaceFaction faction;

//    /// <summary>
//    /// Get this race's starting nexus ability list
//    /// </summary>
//    /// <returns>the race's starting nexus ability list</returns>
//    public abstract AbilityList GetNewNexusAbilities(Nexus nexus);

//    /// <summary>
//    /// Get this race's starting barrack ability list
//    /// </summary>
//    /// <returns>the race's starting barrack ability list</returns>
//    public abstract AbilityList GetNewBarrackAbilities(Barrack barrack);

//    /// <summary>
//    /// Get this race's starting tower ability list
//    /// </summary>
//    /// <returns>the race's starting tower ability list</returns>
//    public abstract AbilityList GetNewTowerAbilities();

//    /// <summary>
//    /// Get a Base abilities list for any race's nexus
//    /// </summary>
//    /// <param name="nexus">The nexus to associate with the abilities</param>
//    /// <returns>A basic skeleton AbilityList object that has all basic tooltip structures common among all race nexus buildings</returns>
//    protected AbilityList BaseNexusAbilities(Nexus nexus)
//    {
//        //create an ability array to plug into an ability list
//        Ability[] nexusAbilities = new Ability[AbilityList.MAX_SIZE];

//        //create skeleton descriptor tooltip
//        //nexusAbilities[0] = new InactiveAbility(new DescriptorTooltip());

//        ////create the abilities for upgrades
//        //nexusAbilities[1] = new LevelAbility(500,new UpgradeTooltip());
//        //nexusAbilities[3] = new LevelAbility(1500, new UpgradeTooltip());
//        //nexusAbilities[4] = new LevelAbility(200, new UpgradeTooltip());
//        //nexusAbilities[5] = new LevelAbility(300, new UpgradeTooltip());
//        //nexusAbilities[6] = new LevelAbility(300, new UpgradeTooltip());
//        //nexusAbilities[7] = new LevelAbility(500, new UpgradeTooltip());

//        //set buildings for the abilities
//        //nexusAbilities[3].SetBuilding(nexus);

//        //create the cast abilities
//        //nexusAbilities[8] = new CastAbility(50, new CastTooltip());
//        //nexusAbilities[9] = new CastAbility(150, new CastTooltip());

//        //TODO: Create nexus abilities for selection of aura & ultimate weapon

//        /**
//         * nexusAbilities[2]
//         * nexusAbilities[10]
//         */


//        return new AbilityList(nexusAbilities);
//    }

//    protected AbilityList BaseBarrackAbilities(Barrack barrack)
//    {
//        Ability[] barrackAbilities = new Ability[AbilityList.MAX_SIZE];



//        return new AbilityList(barrackAbilities);
//    }

//    public MeleeUpgrade Melee
//    {
//        get
//        {
//            return meleeUpgr;
//        }
//    }

//    public GateUpgrade Range
//    {
//        get
//        {
//            return gateUpgr;
//        }
//    }

//    public MageUpgrade Mage
//    {
//        get
//        {
//            return mageUpgr;
//        }
//    }

//    public AuxUpgrade[] Auxiliary
//    {
//        get
//        {
//            return auxUpgrs;
//        }
//    }

//    public DefenseUpgrade Armor
//    {
//        get
//        {
//            return armorUpgr;
//        }
//    }

//    /// <summary>
//    /// Race Constructor
//    /// </summary>
//    /// <param name="raceName">the name of the race</param>
//    //public Race(string raceName)
//    //{
//    //    //set name and faction based on name
//    //    name = raceName;
//    //    if(name == Human.HUMAN_RACE)
//    //    {
//    //        faction = RaceFaction.Alliance;
//    //    }
//    //}

//    /// <summary>
//    /// Get the race's faction in a string format
//    /// </summary>
//    /// <returns>The race faction name as a string</returns>
//    protected string GetRaceFaction()
//    {
//        switch (this.faction)
//        {
//            case RaceFaction.Alliance:
//                return "The Alliance";
//        }

//        throw new System.Exception("No Race Faction found for race with name: " + this.name);
//    }
//}
#endregion