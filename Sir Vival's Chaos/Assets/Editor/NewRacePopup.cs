using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewRacePopup : EditorWindow {

    private static int MAX_RACE_NAME_CHARS = 32;

    private string allowedRaceNameChars = "abcdefghijklmnopqrstuvwxyz";
    private string raceName = "NewRace";

    [MenuItem("Create/NewRace")]
    static void Init()
    {
        NewRacePopup window = CreateInstance<NewRacePopup>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 100);
        window.ShowPopup();
    }

    private void OnGUI()
    {
        EditorGUILayout.PrefixLabel("Race Name: ");
        raceName = GUILayout.TextField(raceName,MAX_RACE_NAME_CHARS);

        if (GUILayout.Button("Create"))
        {
            if (ValidRaceName())
            {
                RaceCreator.CreateRace(raceName);
                this.Close();
            }
            else
            {
                //error handling for invalid raceName
            }

        }

        if (GUILayout.Button("Cancel"))
        {
            this.Close();
        }
    }

    /// <summary>
    /// Validate the race name
    /// </summary>
    /// <returns>true if a valid race name, false otherwise</returns>
    private bool ValidRaceName()
    {
        if(raceName.Length < 2)
        {
            return false;
        }

        foreach(char c in raceName)
        {
            //if the race has a character that isn't in the allowed race name characters string, return false
            if (!(allowedRaceNameChars.Contains(c.ToString().ToLower())))
            {
                return false;
            }
        }

        return true;
    }
}
