using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveAbility : Ability {

    /// <summary>
    /// Constructor for an inactive ability
    /// </summary>
    /// <param name="tt">The tooltip for this ability</param>
    public InactiveAbility(Tooltip tt) : base(false,tt)
    {

    }

}
