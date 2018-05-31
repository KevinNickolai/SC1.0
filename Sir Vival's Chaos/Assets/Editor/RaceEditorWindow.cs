using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RaceEditorWindow : EditorWindow
{
    private TestRace race;

    bool showingUpgrades = false;

    /// <summary>
    /// Layout options for the whole race editor window
    /// </summary>
    GUILayoutOption[] options = { GUILayout.MaxWidth(300.0f) };

    [MenuItem("Window/RaceEditor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RaceEditorWindow window = (RaceEditorWindow)EditorWindow.GetWindow(typeof(RaceEditorWindow));
        //Set minimum size for the window to accomodate fields
        window.minSize = new Vector2(250, 250);
        window.Show();
    }

    private void OnGUI()
    {

        GUILayout.Label("Race Settings", EditorStyles.boldLabel);

        //the race object edit field, of type TestRace, only accepting assets (false as the last parameter)
        race = (TestRace)EditorGUILayout.ObjectField("Race:", race, typeof(TestRace), false, options);


        if (race != null)
        {
            EditorGUI.BeginChangeCheck();

            /**
             *  serialized object to get serialized properties of the race, in order to set them in the editor
             */
            SerializedObject soRace = new SerializedObject(race);

            /**
             * The Serialized property setting for a race name
             */ 
            SerializedProperty spRaceName = soRace.FindProperty("name");
            spRaceName.objectReferenceValue = EditorGUILayout.ObjectField("Name: ", spRaceName.objectReferenceValue, typeof(StringReference), false);

            #region Displaying togglable Inspector Titlebar for upgrades

            SerializedProperty meleeUpgr = soRace.FindProperty("meleeUpgr");
            SerializedProperty rangeUpgr = soRace.FindProperty("rangeUpgr");

            Object[] upgradeObjs = { meleeUpgr.objectReferenceValue };

            showingUpgrades = EditorGUILayout.Foldout(showingUpgrades, "Upgrades");
            if (showingUpgrades)
            {
                meleeUpgr.objectReferenceValue = EditorGUILayout.ObjectField("Melee Upgrade: ", meleeUpgr.objectReferenceValue, typeof(Upgrade), false);
            }
            #endregion

            /**
             * Apply edited changes to the SerializedObject of the race
             */
            if (EditorGUI.EndChangeCheck())
                soRace.ApplyModifiedProperties();
        }

        //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);

        //EditorGUILayout.EndToggleGroup();
    }
}

