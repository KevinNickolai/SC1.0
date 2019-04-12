using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RaceEditorWindow : EditorWindow
{
    private Race race;

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
        RaceEditorWindow window = (RaceEditorWindow)EditorWindow.GetWindow<RaceEditorWindow>();
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

        //the race object edit field, of type Race, only accepting assets (false as the last parameter)
        race = (Race)EditorGUILayout.ObjectField("Race:", race, typeof(Race), false, options);


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
                //get the serialized property for an upgrade, and remove its race association, since we don't know if it will 
                //continue to be used by the race
                SerializedProperty melee = soRace.FindProperty("meleeUpgr");
                AssociateRace(melee, null);

                SerializedProperty gate = soRace.FindProperty("gateUpgr");
                AssociateRace(gate, null);

                SerializedProperty mage = soRace.FindProperty("mageUpgr");
                AssociateRace(mage, null);

                SerializedProperty armor = soRace.FindProperty("armorUpgr");
                AssociateRace(armor, null);

                SerializedProperty fort = soRace.FindProperty("fortUpgr");
                AssociateRace(fort, null);

                SerializedProperty aux = soRace.FindProperty("auxUpgrs");
                if (aux.isArray)
                {
                    for(int i = 0; i < aux.arraySize; ++i)
                    {
                        AssociateRace(aux.GetArrayElementAtIndex(i), null);
                    }
                }

                EditorGUILayout.PropertyField(melee);
                EditorGUILayout.PropertyField(gate);
                EditorGUILayout.PropertyField(mage);
                EditorGUILayout.PropertyField(armor);
                EditorGUILayout.PropertyField(fort);

                //Show the property field for the auxiliary upgrades, including all children of the list
                EditorGUILayout.PropertyField(soRace.FindProperty("auxUpgrs"), true);

                //reassociate all upgrade properties with the race, since by this point any changed property will be considered "associated"
                AssociateRace(melee, race);
                AssociateRace(gate, race);
                AssociateRace(mage, race);
                AssociateRace(armor, race);
                AssociateRace(fort, race);

                if (aux.isArray)
                {
                    for (int i = 0; i < aux.arraySize; ++i)
                    {
                        AssociateRace(aux.GetArrayElementAtIndex(i), race);
                    }
                }
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

    private void AssociateRace(SerializedProperty sp, Race r)
    {
        if (sp.objectReferenceValue != null)
        {
            ((Upgrade)(sp.objectReferenceValue)).SetRace(r);
        }
    }
}

