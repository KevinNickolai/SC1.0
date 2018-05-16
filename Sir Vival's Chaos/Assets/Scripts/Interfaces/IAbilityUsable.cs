using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface describing something with usable abilities
/// </summary>
public interface IAbilityUsable {
    AbilityList Abilities { get; }
}
