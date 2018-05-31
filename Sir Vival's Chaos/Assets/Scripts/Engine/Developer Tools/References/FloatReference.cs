using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing an FloatReference type that can allow for a variable or constant reference to an float in memory
/// </summary>
[CreateAssetMenu(fileName = "NewFloatReference", menuName = "Values/References/FloatReference", order = 2)]
public class FloatReference : Reference<float,FloatVariable> { }
