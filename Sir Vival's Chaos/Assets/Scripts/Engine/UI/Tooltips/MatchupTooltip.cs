using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing a tooltip for a StatType's various Matchups
/// </summary>
public class MatchupTooltip : Tooltip {
    
    /// <summary>
    /// Initialize this MatchupTooltip
    /// </summary>
    /// <param name="statTypeName">The name of the StatType that the tooltip shows matchups for</param>
    public void Init(string statTypeName, TooltipSection section)
    {
        /**
         * Initialize the title StringReference to set this tooltip's title
         */
        StringReference title = CreateInstance<StringReference>();
        title.SetConstant(statTypeName);
        this.SetTitle(title);
        this.AddSection(section);
    }

}