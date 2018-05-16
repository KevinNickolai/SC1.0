using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTooltip : Tooltip{

    /// <summary>
    /// static string for the Effect header of a CastTooltip
    /// </summary>
    public static string EFFECT_HEADER = "Effect";
	
    /// <summary>
    /// CastTooltip Constructor
    /// </summary>
    public CastTooltip()
    {
        AddSection(new TooltipSection(EFFECT_HEADER));
    }
}
