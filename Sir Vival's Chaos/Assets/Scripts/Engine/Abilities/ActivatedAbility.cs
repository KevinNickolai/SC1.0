using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for any activated ability
/// </summary>
public abstract class ActivatedAbility : Ability {

    /// <summary>
    /// OnEnable initializes the instance when the instance is loaded
    /// </summary>
    private void OnEnable()
    {
        SetActivatable(true);
    }

    /// <summary>
    /// Activate the activated ability
    /// </summary>
    public abstract void Activate();
}
