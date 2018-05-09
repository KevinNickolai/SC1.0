using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface describing a Levelable object
/// Levelable objects are also describable
/// </summary>
public interface ILevelable : IDescribable{
    
    int Level { get; }

    void LevelUp();

}
