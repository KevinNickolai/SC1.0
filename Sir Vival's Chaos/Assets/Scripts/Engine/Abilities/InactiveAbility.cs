using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes an inactive ability
/// </summary>
[CreateAssetMenu(fileName = "NewInactiveAbility", menuName = "Abilities/Ability/InactiveAbility", order = 5)]
public class InactiveAbility : Ability {

    /// <summary>
    /// OnEnable to initialize the instance once it is loaded
    /// </summary>
    private void OnEnable()
    {
        SetActivatable(false);
    }

}
