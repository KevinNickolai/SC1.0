using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RaceEditorWindow : EditorWindow
{
    private TestRace race;

    bool showingUpgrades = false;
    bool showingAbilityLists = false;
    Vector2 scrollPosition = Vector2.zero;
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
        window.maxSize = new Vector2(500, 500);
        window.Show();
    }

    private void OnGUI()
    {
        //start a scrolling view to encapsulate the whole Race Editor Window
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false);

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
            EditorGUILayout.PropertyField(soRace.FindProperty("name"));

            #region Displaying Foldout for Race Upgrades

            //foldout for the upgrade section in the race editor
            showingUpgrades = EditorGUILayout.Foldout(showingUpgrades, "Upgrades");
            if (showingUpgrades)
            {
                EditorGUILayout.PropertyField(soRace.FindProperty("meleeUpgr"));
                EditorGUILayout.PropertyField(soRace.FindProperty("rangeUpgr"));
                EditorGUILayout.PropertyField(soRace.FindProperty("mageUpgr"));
                EditorGUILayout.PropertyField(soRace.FindProperty("armorUpgr"));

                //Show the property field for the auxiliary upgrades, including all children of the list
                EditorGUILayout.PropertyField(soRace.FindProperty("auxUpgrs"), true);
            }
            #endregion

            #region Display AbilityLists for buildings

            showingAbilityLists = EditorGUILayout.Foldout(showingAbilityLists, "Building Abilities");
            if (showingAbilityLists)
            {
                EditorGUILayout.PropertyField(soRace.FindProperty("nexusAbilities"));
                EditorGUILayout.PropertyField(soRace.FindProperty("barrackAbilities"));
                EditorGUILayout.PropertyField(soRace.FindProperty("towerAbilities"));
            }
            #endregion

            /**
             * Apply edited changes to the SerializedObject of the race
             */
            if (EditorGUI.EndChangeCheck())
                soRace.ApplyModifiedProperties();
        }

        GUILayout.EndScrollView();

        //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);

        //EditorGUILayout.EndToggleGroup();
    }
}

