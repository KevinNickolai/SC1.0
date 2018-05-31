using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The set of buildings to track for the player
/// </summary>
[CreateAssetMenu(fileName = "NewBuildingSet", menuName = "Variables/RuntimeSets/BuildingSet",order = 1)]
public class BuildingSet : RuntimeSet<Building> { }
