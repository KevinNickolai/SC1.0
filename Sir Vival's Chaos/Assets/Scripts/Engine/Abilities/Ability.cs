using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability {

    /// <summary>
    /// flag indicating if the ability is activatable or not
    /// readonly indicates this is known when the object is created,
    /// and a constant otherwise
    /// </summary>
    private readonly bool isActivatable;
    
    /// <summary>
    /// Flag indicating if an ability can be activated
    /// </summary>
    public bool IsActivatable
    {
        get
        {
            return isActivatable;
        }
    }

    private Tooltip tooltip;

    public Tooltip Tooltip
    {
        get
        {
            return tooltip;
        }
    }

    /// <summary>
    /// Constructor for an ability
    /// </summary>
    /// <param name="activatable">flag indicating if the ability can be activated</param>
    protected Ability(bool activatable)
    {
        isActivatable = activatable;
    }
}
