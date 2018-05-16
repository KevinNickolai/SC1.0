using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptorTooltip : Tooltip {

    /// <summary>
    /// Header for Unit TooltipSection on a DescriptorTooltip
    /// </summary>
    public static string UNIT_HEADER = "Units";

    /// <summary>
    /// Header for Building TooltipSection on a DescriptorTooltip
    /// </summary>
    public static string BUILDING_HEADER = "Buildings";

    /// <summary>
    /// Header for Upgrade TooltipSection on a DescriptorTooltip
    /// </summary>
    public static string UPGRADE_HEADER = "Upgrades";

    /// <summary>
    /// Header for Trait TooltipSection on a DescriptorTooltip
    /// </summary>
    public static string TRAIT_HEADER = "Traits";

    /// <summary>
    /// Header for Difficulty TooltipSection on a DescriptorTooltip
    /// </summary>
    public static string DIFFICULTY_HEADER = "Difficulty";

    /// <summary>
    /// DescriptorTooltip constructor
    /// </summary>
    public DescriptorTooltip()
    {
        //Create all sections for a descriptor tooltip
        AddSection(new TooltipSection(UNIT_HEADER));
        AddSection(new TooltipSection(BUILDING_HEADER));
        AddSection(new TooltipSection(UPGRADE_HEADER));
        AddSection(new TooltipSection(TRAIT_HEADER));
        AddSection(new TooltipSection(DIFFICULTY_HEADER));
    }

}
