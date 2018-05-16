using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTooltip : Tooltip {

    public static string GIVES_HEADER = "Gives";

    /// <summary>
    /// UpgradeTooltip Constructor
    /// </summary>
    public UpgradeTooltip()
    {
        //add a multiline tooltip section, for listing the upgrade that the header gives
        AddSection(new MultiLineTooltipSection(GIVES_HEADER, ""));
    }
}
