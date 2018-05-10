using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that describes a describable object
/// </summary>
public interface IDescribable {

    string Name { get; }

    Player Player { get; }

    int MinDamage { get; }
    int MaxDamage { get; }

    int Armor { get; }
}
