using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing a StringReference object to hold Unity Inspector StringVariables or use a string constant
/// </summary>
[CreateAssetMenu(fileName = "NewStringReference", menuName = "Values/References/StringReference")]
public class StringReference : Reference<string,StringVariable> { }
