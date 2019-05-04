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

    public override void SetProperties(Race race, Player p)
    {
        base.SetProperties(race, p);

        this.abilities = race.NexusAbilities;

        foreach(Ability a in race.NexusAbilities)
        {
            if(a != null)
                a.SetBuilding(this);
        }

        //set the levelables for the nexus abilities
        abilities[NexusAbilityList.BUILDING_UPGRADE].SetLevelable(this);

        abilities[NexusAbilityList.MAGE_UPGRADE].SetLevelable(race.MageUpgrade);

        abilities[NexusAbilityList.MELEE_UPGRADE].SetLevelable(race.MeleeUpgrade);

        abilities[NexusAbilityList.RANGE_UPGRADE].SetLevelable(race.GateUpgrade);

        abilities[NexusAbilityList.ARMOR_UPGRADE].SetLevelable(race.ArmorUpgrade);
    }   
}
