using UnityEditor;
using UnityEngine;

/// <summary>
/// Generic Reference Drawer for all types of References;
/// 
/// Idea based on Ryan Hipple's 2017 Unite talk on scriptableobjects found:
/// https://www.youtube.com/watch?v=raQ3iHhE_Kk
/// 
/// Unity does not support CustomPropertyDrawers with generic types in them as of May 2018,
/// so for each reference that exists in the project, it's required to add all different types of
/// references above the GenericReferenceDrawer declaration to have them use this custom property drawer.
/// </summary>
[CustomPropertyDrawer(typeof(IntReference))]
[CustomPropertyDrawer(typeof(FloatReference))]
[CustomPropertyDrawer(typeof(StringReference))]
public class GenericReferenceDrawer : PropertyDrawer
{
    /// <summary>
    /// Options to display in the popup to select constant or variable.
    /// </summary>
    private readonly string[] popupOptions =
        { "Use Constant", "Use Variable" };

    /// <summary> Cached style to use to draw the popup button. </summary>
    private GUIStyle popupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupStyle == null)
        {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            popupStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        if (property.objectReferenceValue)
        {
            EditorGUI.BeginChangeCheck();

            SerializedObject so = new SerializedObject(property.objectReferenceValue);

            // Get properties
            SerializedProperty useConstant = so.FindProperty("UseConstant");
            SerializedProperty constantValue = so.FindProperty("ConstantValue");
            SerializedProperty variable = so.FindProperty("Variable");

            /**
             * Original serialized properties; unable to work 
             */
            //SerializedProperty useConstant =  property.FindPropertyRelative("UseConstant");
            //SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
            //SerializedProperty variable = property.FindPropertyRelative("Variable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);

            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position,
                useConstant.boolValue ? constantValue : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                //property.serializedObject.ApplyModifiedProperties();
                so.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
        }
        else
        {
            EditorGUI.PropertyField(position, property, GUIContent.none);
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true);
    }
}