using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing an IntReference type that can allow for a variable or constant reference to an integer in memory
/// </summary>
[CreateAssetMenu(fileName = "NewIntReference", menuName = "Values/References/IntReference", order = 1)]
public class IntReference : Reference<int,IntVariable> { }