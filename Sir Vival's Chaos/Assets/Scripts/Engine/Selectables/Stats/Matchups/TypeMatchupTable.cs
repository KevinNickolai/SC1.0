using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class Describing The Type Matchup Table for all StatTypes
/// </summary>
[CreateAssetMenu(fileName = "NewTypeMatchup", menuName = "Stats/TypeMatchup")][System.Serializable]
public class TypeMatchupTable : ScriptableObject
{
    /// <summary> Default Matchup Percentage Modifier </summary>
    const int DEFAULT_MODIFIER = 100;

    #region StatType Lists
    /// <summary>
    /// The ArmorTypes to be included in the Matchup Table
    /// </summary>
    [SerializeField]
    List<ArmorType> armorTypes;

    /// <summary>
    /// The DamageTypes included in the Matchup Table
    /// </summary>
    [SerializeField]
    List<DamageType> damageTypes;

    /// <summary>
    /// 2D List of type IntListWrapper; IntListWrapper used instead of List of primitive ints for Unity Serialization purposes.
    /// </summary>
    [SerializeField][HideInInspector]
    List<IntListWrapper> matchups;
    #endregion

    /// <summary>IComparer used to sort Matchup percentages in descending order (highest % to lowest)</summary>
    private class MatchupComparer : IComparer<int>
    {
        public int Compare(int i1, int i2)
        {
            //sort descending, by having lesser numbers return 1 (greater than) a bigger number
            if (i1 <= i2)
                return 1;
            else
                return -1;
        }
    }



    /// <summary>
    /// Get the list of a specific DamageType or ArmorType matchup ordering
    /// </summary>
    /// <param name="index"></param>
    /// <param name="isDamageType"></param>
    /// <returns></returns>
    private List<int> GetUnorderedMatchupList(int index, bool isDamageType)
    {
        return isDamageType ? matchups[index].List : GetArmorList(index);
    }

    /// <summary>
    /// Get list of ints, in relation to matchup percentages of an ArmorType vs all DamageTypes, with respect to ArmorType percentages
    /// </summary>
    /// <param name="index">index of the ArmorType to get matchups for</param>
    /// <returns>List of ints of matchup percentages, with respect to how much an armor type defends against a specific DamageType</returns>
    private List<int> GetArmorList(int index)
    {
        List<int> retList = new List<int>();

        //loop through all of the matchups to get the integer corresponding to the ArmorType at the given index
        for(int i = 0; i < matchups.Count; ++i)
        {
            //add the matchup of a single DamageType at a time, int order
            retList.Add(matchups[i][index]);
        }

        return retList;
    }

    /// <summary>
    /// Create a SortedList of a StatType's matchups
    /// </summary>
    /// <param name="index">index into the damageTypes/armorTypes lists for the 2 different StatTypes</param>
    /// <param name="isDamageType">flag indicating the StatType</param>
    /// <returns>A SortedList of 2 ints that have a key of the percentage given/taken from the matchup, and a value of the index into the
    /// opposite StatType's list of types, to keep track of the names of those matchups.</returns>
    private SortedList<int,int> CreateSortedMatchup(int index, bool isDamageType)
    {
        //the unordered list of matchups for the stat type
        List<int> matchups = GetUnorderedMatchupList(index, isDamageType);

        //create the ordered matchup list with a matchup comparer, to allow for duplicate keys with differing values
        SortedList<int, int> orderedMU = new SortedList<int, int>(new MatchupComparer());
        for(int i = 0; i < matchups.Count; ++i)
        {
            orderedMU.Add(matchups[i], i);
        }

        return orderedMU;
    }

    public void Awake()
    {
        OnEnable();    
    }

    public void OnEnable()
    {
        /**
         * Assign matchup properties for every StatType tracked by the 
         */
        int i = 0;
        foreach(ArmorType at in armorTypes)
        {
            at.SetMatchups(this, i, GetTextForMatchup(i,false));
            ++i;
        }

        i = 0;
        foreach(DamageType dt in damageTypes)
        {
            dt.SetMatchups(this, i, GetTextForMatchup(i, true));
            ++i;
        }
    }

    /// <summary>
    /// Get a damage modifier a specific damage type has on a specific armor type
    /// </summary>
    /// <param name="dt">DamageType to check the modifier for</param>
    /// <param name="at">ArmorType to check the modifier for</param>
    /// <returns></returns>
    public float GetDamageModifier(DamageType dt, ArmorType at)
    {
        return (matchups[dt.MatchupIndex][at.MatchupIndex])/100.0f;
    }

    /// <summary>
    /// Get Text for a specific type matchup
    /// </summary>
    /// <param name="index">the index of the StatType in its respective damageType or armorType list</param>
    /// <param name="isDamageType">flag for a StatType that derives from DamageType or ArmorType</param>
    /// <returns>A string of text that displays all matchups of a StatType</returns>
    private string GetTextForMatchup(int index, bool isDamageType)
    {
        //Create a sorted list of the matchups for the StatType 
        SortedList<int, int> statMU = CreateSortedMatchup(index, isDamageType);

        //assign the opposite StatType list, in order to have the listing of the names of the opposite StatType matchups at all their given indecies in the statMU SortedList.
        List<StatType> oppositeStatType = isDamageType ? armorTypes.ConvertAll<StatType>(x => x as StatType) : damageTypes.ConvertAll<StatType>(x => x as StatType);

        //string addition to each newline of the body for the matchups, indicating what percentages are given or taken from the opposite StatTypes
        string percentConversion = isDamageType ? "% to " : "% from ";

        string body = "";

        //add every matchup to the body of the text in the format of
        //(percentage of damage)% to/from (StatTypeName)
        foreach(var mu in statMU)
        {
            body += mu.Key + percentConversion + oppositeStatType[mu.Value].name + '\n';    
        }

        return body;
    }
}
