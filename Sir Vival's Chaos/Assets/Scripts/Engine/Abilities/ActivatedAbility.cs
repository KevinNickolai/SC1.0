using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatedAbility : Ability {

    /// <summary>
    /// Initialize this activatable ability with a
    /// base ability class constructor call that
    /// indicates isActivatable as true.
    /// </summary>
    protected ActivatedAbility() : base(true) { }

    public abstract void Activate();
}
