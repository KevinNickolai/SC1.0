using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface describing something levelable
///
/// Levelable things must have a Level accessor
/// as well as a way to level up.
/// </summary>
public interface ILevelable {
    
    int Level { get; }

    void LevelUp();

}
