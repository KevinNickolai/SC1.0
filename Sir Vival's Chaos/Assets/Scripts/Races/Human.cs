using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Race {

    public static string HUMAN_RACE = "Human";

    //Should probably figure out a way to make this more concise or not contain it in code
    //some sort of file maybe
    #region Human Traits

    private const string NEXUS_NAME = "Castle";
    private const string BARRACK_NAME = "Barrakcs";
    private const string TOWER_NAME = "Arrow Tower";

    private const string MELEE_UNIT = "Footman";
    private const string RANGED_UNIT = "Crossbowman";
    private const string SIEGE_UNIT = "Knight";
    private const string AIR_UNIT = "Griffin Rider";
    private const string ARTILLERY_UNIT = "Ballista";
    
    #endregion

    /// <summary>
    /// Human constructor
    /// </summary>
    public Human() : base(HUMAN_RACE)
    {
    }

    /// <summary>
    /// Get new nexus abilities for the human race
    /// </summary>
    /// <returns>new AbilityList of nexus abilities</returns>
    public override AbilityList GetNewNexusAbilities(Nexus nexus)
    {
        //get the base ability list for a nexus
        AbilityList nexusAbilities = BaseNexusAbilities(nexus);

        InitializeDescriptor(nexusAbilities);

        
        //UpgradeTooltip upgrTT = (UpgradeTooltip)nexusAbilities[3].Tooltip;

        //upgrTT.Title = "Upgrade ";








        //upgrTT = (UpgradeTooltip)nexusAbilities[4].Tooltip;

        ////get the upgrade section for the 1st upgrade ability
        ////Cast the section to a multiline section to add lines to the body
        //((MultiLineTooltipSection)(upgrTT.GetSection(UpgradeTooltip.GIVES_HEADER))).AddLine("+4 Melee to Footman");
        //((MultiLineTooltipSection)(upgrTT.GetSection(UpgradeTooltip.GIVES_HEADER))).AddLine("+6 Melee to Knight");

        return nexusAbilities;
        //Ability[] nexusAbilities = new Ability[AbilityList.MAX_SIZE];
        //return new AbilityList(nexusAbilities);
    }

    /// <summary>
    /// Initialize the descriptor for the nexus abilities
    /// </summary>
    /// <param name="nexusAbilities">The AbilityList for the nexus</param>
    private void InitializeDescriptor(AbilityList nexusAbilities)
    {

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