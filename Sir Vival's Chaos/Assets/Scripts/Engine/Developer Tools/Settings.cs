using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Settings Class for defining specific gamemode settings
/// </summary>
[CreateAssetMenu(fileName = "NewSettings", menuName = "Settings")]
public class Settings : ScriptableObject {

    [SerializeField]
    private TypeMatchupTable matchups;

}
