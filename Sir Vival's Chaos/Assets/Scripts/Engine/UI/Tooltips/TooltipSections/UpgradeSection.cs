using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeSection", menuName = "Tooltips/TooltipSections/UpgradeSection", order = 1)]
public class UpgradeSection : TooltipSection
{

    /// <summary>
    /// Called when the script is instantiated
    /// </summary>
    private void OnEnable()
    {
        SetHeader("Upgrades");
    }

}
