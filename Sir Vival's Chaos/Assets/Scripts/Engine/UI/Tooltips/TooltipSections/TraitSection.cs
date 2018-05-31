using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTraitSection", menuName = "Tooltips/TooltipSections/TraitSection", order = 1)]
public class TraitSection : TooltipSection
{

    /// <summary>
    /// Called when the script is instantiated
    /// </summary>
    private void OnEnable()
    {
        SetHeader("Traits");
    }

}