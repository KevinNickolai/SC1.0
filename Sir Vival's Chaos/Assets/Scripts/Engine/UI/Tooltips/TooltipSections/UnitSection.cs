using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitSection", menuName = "Tooltips/TooltipSections/UnitSection", order = 1)]
public class UnitSection : TooltipSection {

    /// <summary>
    /// Called when the script is instantiated
    /// </summary>
    private void OnEnable()
    {
        SetHeader("Units");
    }

}
