using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : LevelBuilding {

    static int MAX_LEVEL = 3;

    /// <summary>
    /// Nexus Constructor
    /// </summary>
	public Nexus()
    {
        this.SetMaxLevel(MAX_LEVEL);
    }

    public override void SetProperties(Race race)
    {
        this.abilities = race.NexusAbilities;

        //set the levelables for the nexus abilities
        abilities[NexusAbilityList.BUILDING_UPGRADE].SetLevelable(this);

        abilities[NexusAbilityList.MAGE_UPGRADE].SetLevelable(race.Mage);

        abilities[NexusAbilityList.MELEE_UPGRADE].SetLevelable(race.Melee);

        abilities[NexusAbilityList.RANGE_UPGRADE].SetLevelable(race.Range);

        abilities[NexusAbilityList.ARMOR_UPGRADE].SetLevelable(race.Armor);
    }   
}
