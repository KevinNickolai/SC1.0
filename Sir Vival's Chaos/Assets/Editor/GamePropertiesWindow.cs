using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GamePropertiesWindow : EditorWindow
{
    /// <summary>
    /// Settings object for the GamePropertiesWindow to display
    /// </summary>
    private Settings settings;

    /// <summary>
    /// Flag to show a foldout of matchups
    /// </summary>
    private bool showMatchups = false;

    /// <summary>
    /// Position in the scroll view of the window
    /// </summary>
    private Vector2 scrollPos = Vector2.zero;

    [MenuItem("Window/GameProperties/gp")]
    static void Init()
    {
        //get existing window if open, make a new one if none are open
        GamePropertiesWindow window = (GamePropertiesWindow)GetWindow<GamePropertiesWindow>();

        window.minSize = new Vector2(250, 250);
        window.maxSize = new Vector2(500, 500);
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Properties", EditorStyles.boldLabel);

        settings = (Settings)EditorGUILayout.ObjectField("Matchup Table:", settings, typeof(Settings), false);

        if (settings != null)
        {
            SerializedObject soSettings = new SerializedObject(settings);

            SerializedProperty matchups = soSettings.FindProperty("matchups");

            showMatchups = EditorGUILayout.Foldout(showMatchups, new GUIContent("Matchups"));
            if (showMatchups)
            {
                EditorGUILayout.PropertyField(matchups, GUIContent.none);
            }
            soSettings.ApplyModifiedProperties();
        }
    }
}
