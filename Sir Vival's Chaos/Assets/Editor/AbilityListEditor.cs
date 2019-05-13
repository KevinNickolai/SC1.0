using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbilityList))]
public class AbilityListDrawer : Editor
{

    SerializedProperty soAbilityList;

    public void OnEnable()
    {
        soAbilityList = serializedObject.FindProperty("list");        
    }

    public override void OnInspectorGUI()
    {
        //update the object with any potentially unrepresented changes made to it
        serializedObject.Update();

        //start the check for serialized object changes
        EditorGUI.BeginChangeCheck();

        for(int i = 0; i < soAbilityList.arraySize; ++i)
        {
            EditorGUILayout.PropertyField(soAbilityList.GetArrayElementAtIndex(i));
        }

        //apply changed properties if anything was changed on the serialized object
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
        
        //label = EditorGUI.BeginProperty(position, label, property);
        //EditorGUI.PropertyField(position, property, label, true);

        //if(property.objectReferenceValue != null)
        //{
        //    EditorGUI.BeginChangeCheck();

        //    SerializedObject soAbilityList = new SerializedObject(property.objectReferenceValue);

        //    SerializedProperty abilityList = soAbilityList.FindProperty("list");



        //    for (int i = 0; i < abilityList.arraySize; ++i)
        //    {            
        //        // Calculate rect for configuration button
        //        position.yMin += 25.0f;
        //        EditorGUI.PropertyField(position, abilityList.GetArrayElementAtIndex(i));
        //    }


        //    if (EditorGUI.EndChangeCheck())
        //    {
        //        soAbilityList.ApplyModifiedProperties();
        //    }
        //}
    }
}