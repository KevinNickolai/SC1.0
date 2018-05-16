using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Race {

    public Orc() : base("Orc")
    {
    }


    /// <summary>
    /// Get new nexus abilities for the human race
    /// </summary>
    /// <returns>new AbilityList of nexus abilities</returns>
    public override AbilityList GetNewNexusAbilities(Nexus nexus)
    {
        Ability[] nexusAbilities = new Ability[AbilityList.MAX_SIZE];

        return new AbilityList(nexusAbilities);
    }

    /// <summary>
    /// Get new barrack abilities for the human race
    /// </summary>
    /// <returns>new AbilityList of barrack abilities</returns>
    public override AbilityList GetNewBarrackAbilities(Barrack barrack)
    {
        Ability[] barrackAbilities = new Ability[AbilityList.MAX_SIZE];

        return new AbilityList(barrackAbilities);
    }

    /// <summary>
    /// Get new tower abilities for the human race
    /// </summary>
    /// <returns>new AbilityList of tower abilities</returns>
    public override AbilityList GetNewTowerAbilities()
    {
        Ability[] towerAbilities = new Ability[AbilityList.MAX_SIZE];

        return new AbilityList(towerAbilities);
    }
}
