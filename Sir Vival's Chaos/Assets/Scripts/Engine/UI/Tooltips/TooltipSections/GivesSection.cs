using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGivesSection", menuName = "Tooltips/TooltipSections/GivesSection")]
public class GivesSection : HeaderTooltipSection
{

    /// <summary>
    /// called on script instantiation
    /// </summary>
    private void OnEnable()
    {
        SetHeader("Gives");
    }
}