using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * Reason for ReadOnly Field:
 * ScriptableObjects I use have some values that should only be filled with a specific value based on
 * the type; i.e. CastAbilities should have a CostType of Mana only. I'd still like to be able to use
 * the inspector to see the value that is provided through the CastAbility class so I understand that
 * any cost I put into the inspector is a mana cost and not a gold cost.
 * 
 * Solution for ReadOnly field for Unity's inspector found at:
 * https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
 */

/// <summary>
/// Class to describe Readonly Attribute
/// </summary>
public class ReadOnlyAttribute : PropertyAttribute
{

}

/// <summary>
/// Class to describe the ReadOnlyDrawer in Unity's inspector
/// </summary>
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}