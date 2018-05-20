using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitSection", menuName = "Tooltips/TooltipSections/UnitSection", order = 1)]
public class UnitSection : TooltipSection {

    private static string UNITS_HEADER = "Units";

    private void OnEnable()
    {
        SetHeader(UNITS_HEADER);
    }
}
