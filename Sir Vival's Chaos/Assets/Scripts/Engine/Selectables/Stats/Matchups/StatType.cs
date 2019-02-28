using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract base class for a DamageType or ArmorType
/// </summary>
[System.Serializable]
public abstract class StatType : ScriptableObject {

    /// <summary>
    /// The tooltip for the StatType
    /// </summary>
    private MatchupTooltip matchupTT;

    /// <summary>
    /// matchups container
    /// </summary>
    private TypeMatchupTable matchups;

    /// <summary>
    /// The image to display when the StatType is hovered over
    /// </summary>
    [SerializeField]
    private Sprite typeSprite;

    /// <summary>
    /// The sprite used to represent the Type
    /// </summary>
    public Sprite SpriteOfType
    {
        get
        {
            return typeSprite;
        }
    }

    /// <summary>
    /// A lookup index into the matchup table
    /// </summary>
    private int lookupIndex = -1;

    /// <summary>
    /// Index of the StatType into the matchups object
    /// </summary>
    public int MatchupIndex
    {
        get
        {
            return lookupIndex;
        }
    }

    public void SetMatchups(TypeMatchupTable table, int index, string matchupTooltipBody)
    {
        //set the matchups table and index to find the StatType in the table later on
        matchups = table;
        lookupIndex = index;

        TooltipSection section = CreateInstance<TooltipSection>();
        section.Init(matchupTooltipBody);

        matchupTT = CreateInstance<MatchupTooltip>();
        matchupTT.Init(this.name,section);
    }

    /// <summary>
    /// Get the Tooltip for the matchups of this StatType
    /// </summary>
    /// <returns></returns>
    public Tooltip GetMatchupTooltip()
    {
        if(!matchupTT)
        {
            Debug.LogError("StatType " + name + " tooltip is null.");
        }
        return matchupTT;
    }
}
