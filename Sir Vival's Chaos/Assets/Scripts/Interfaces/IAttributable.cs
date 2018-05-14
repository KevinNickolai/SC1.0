using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface describing an Attributable object
/// 
/// Attributable objects by nature of the game must be levelable objects;
/// e.g. Heroes have attributes, and must also therefore be levelable
/// in order for attributes to increase and scale with level.
/// </summary>
public interface IAttributable : ILevelableObject {

	int Strength { get; set; }
    int Agility { get; set; }
    int Intelligence { get; set; }

}
