using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing a list of abilities
/// IEnumerable interface implemented for iteration of the ability list
/// 
/// Basis of IEnumerable code found at:
/// https://msdn.microsoft.com/en-us/library/system.collections.ienumerable.getenumerator(v=vs.110).aspx
/// </summary>
[CreateAssetMenu(fileName = "NewAbilityList", menuName = "Abilities/AbilityList", order = 1)]
public class AbilityList : ScriptableObject, IEnumerable
{

    /// <summary>
    /// Get the ability at index key of the ability list
    /// </summary>
    /// <param name="key">the index of the ability to get</param>
    /// <returns>the ability at index key</returns>
    public Ability this[int key]
    {
        get
        {
            try
            {
                return list[key];
            }
            catch(System.IndexOutOfRangeException)
            {
                Debug.Log("Ability at index " + key + " Produced out of range exception; returning null ability");
                return null;
            }
        }
    }

    // Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public AbilityEnum GetEnumerator()
    {
        return new AbilityEnum(list);
    }

    /// <summary>
    /// The max size of an AbilityList
    /// </summary>
    public static int MAX_SIZE = 12;

    /// <summary>
    /// The underlying list of the abilities
    /// </summary>
    [SerializeField]
    private Ability[] list;

    public AbilityList(Ability[] al)
    {
        list = al;
    }

    /// <summary>
    /// Replace an ability in the AbilityList
    /// </summary>
    /// <param name="toReplace">the ability to replace</param>
    /// <param name="replacement">the replacement ability</param>
    public void Replace(Ability toReplace, Ability replacement)
    {
        throw new System.Exception("AbilityList.Replace not implemented yet");
    }
}
