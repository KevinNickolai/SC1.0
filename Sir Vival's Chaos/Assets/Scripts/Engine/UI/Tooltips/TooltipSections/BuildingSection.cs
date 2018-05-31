using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingSection", menuName = "Tooltips/TooltipSections/BuildingSection", order = 1)]
public class BuildingSection : TooltipSection
{

    /// <summary>
    /// Called when the script is instantiated
    /// </summary>
    private void OnEnable()
    {
        SetHeader("Buildings");
    }

}
