using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for a general ability
/// Inheirits from ScriptableObject to allow for Serialization and better data storage,
/// since abilities are all base data.
/// </summary>
public abstract class Ability : ScriptableObject{

    /// <summary>
    /// flag indicating if the ability is activatable or not
    /// readonly indicates this is known when the object is created,
    /// and a constant otherwise
    /// </summary>
    private bool isActivatable;
    
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

    /// <summary>
    /// Set the ability's status flag of activatable
    /// </summary>
    /// <param name="activatable">flag indicating if the ability is activatable or not</param>
    protected void SetActivatable(bool activatable)
    {
        isActivatable = activatable;
    }

    /// <summary>
    /// The tooltip for the ability
    /// </summary>
    [SerializeField]
    private Tooltip tooltip;

    /// <summary>
    /// The tooltip for the ability
    /// </summary>
    public Tooltip Tooltip
    {
        get
        {
            return tooltip;
        }
    }

    /// <summary>
    /// The sprite for the ability
    /// </summary>
    [SerializeField]
    private Sprite sprite;

    /// <summary>
    /// The sprite for the ability
    /// </summary>
    public Sprite Sprite
    {
        get { return sprite; }
    }

    public virtual void SetLevelable(ILevelable b) { }
    public virtual void SetBuilding(Building b) { }
}
