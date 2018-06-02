using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Static class for race creation
/// </summary>
public static class RaceCreator{

    #region constant string names for folders
    private static string ROOT_RACES_FOLDER_PATH = "Assets/Data/Races/TC";
    private static string NEXUS_ABILITIES_FOLDER_NAME = "NexusAbilities";
    private static string BARRACK_ABILITIES_FOLDER_NAME = "BarrackAbilities";
    private static string TOWER_ABILITIES_FOLDER_NAME = "TowerAbilities";
    private static string ABILITIES_FOLDER_NAME = "Abilities";
    #endregion

    /**
     * Note that for file distinction between different races, these
     * string names for assets should be prefixed in code by the 
     * raceName passed in when creating a race.
     */
    #region constant string names for assets
    private static string NEXUS_ABILITY_LIST_NAME = "NexusAbilities";
    private static string BARRACK_ABILITY_LIST_NAME = "BarrackAbilities";
    private static string TOWER_ABILITY_LIST_NAME = "TowerAbilities";
    #endregion
    /// <summary>
    /// The file extension to add to the end of assets
    /// </summary>
    private static string FILE_EXT = ".asset";

    public static void CreateRace(string raceName)
    {
        string baseRaceFolder = ROOT_RACES_FOLDER_PATH + "/" + raceName;

        //does the folder of the raceName already exist?
        //if (AssetDatabase.IsValidFolder(baseRaceFolder))
        //{
        //    Debug.LogError(baseRaceFolder + " already exists. Enter a different race name for race creation.");
        //    return;
        //}

        //create the folder of the raceName
        string baseRaceGUID = AssetDatabase.CreateFolder(ROOT_RACES_FOLDER_PATH, raceName);

        //translate the GUID returned by create folder into the actual folder name,
        //in case folder creation of races with the same name is allowed
        baseRaceFolder = AssetDatabase.GUIDToAssetPath(baseRaceGUID);

        TestRace raceAsset = CreateRaceAsset(baseRaceFolder, raceName);

        CreateAbilities(baseRaceFolder,raceName, raceAsset);
        //CreateUnits();
        //CreateUpgrades();
        

    }

    /// <summary>
    /// create the race asset and any assets added to the race asset
    /// </summary>
    /// <param name="baseFolder">the folder to put the race asset in</param>
    /// <param name="raceName">the name of the race</param>
    /// <returns>The Race Asset created</returns>
    private static TestRace CreateRaceAsset(string baseFolder, string raceName)
    {
        //the asset path for the Race asset file
        string raceAssetPath = baseFolder + "/" + raceName + FILE_EXT;

        //create the Race object for the race
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TestRace>(), raceAssetPath);

        //create a string reference to associate to the Race's name
        StringReference srName = ScriptableObject.CreateInstance<StringReference>();
        srName.name = (raceName + "RaceName");

        //The string reference must be first added to the Race Asset to allow for the setting of the name property of the race to the asset we're adding to the race asset
        AssetDatabase.AddObjectToAsset(srName, raceAssetPath);
        //reimport the asset to show the added asset
        AssetDatabase.ImportAsset(raceAssetPath);

        TestRace race = (TestRace)AssetDatabase.LoadAssetAtPath(raceAssetPath, typeof(TestRace));

        //create a serialized object to make the connection between the Race asset and the StringReference
        SerializedObject soRace = new SerializedObject(race);
        (soRace.FindProperty("name")).objectReferenceValue = srName;
        srName.SetConstant(raceName);

        //Apply changed properties to the object created for the StringReference Connection
        soRace.ApplyModifiedProperties();

        return race;
    }

    #region CreateAbilities Functions

    /// <summary>
    /// Create the Abilities for the race
    /// </summary>
    /// <param name="baseFolder"></param>
    /// <param name="raceName"></param>
    private static void CreateAbilities(string baseFolder, string raceName, TestRace raceAsset)
    {
        /**
         * Create the Abilities folder and retrieve its path using its GUID
         */
        string abilitiesGUID = AssetDatabase.CreateFolder(baseFolder, ABILITIES_FOLDER_NAME);
        string abilitiesPath = AssetDatabase.GUIDToAssetPath(abilitiesGUID);


        /**
         * Create the ability lists
         */
        AbilityList nexusAL = CreateNexusAbilities(abilitiesPath, raceName);
        AbilityList barrackAL = CreateBarrackAbilities(abilitiesPath, raceName);      
        AbilityList towerAL = CreateTowerAbilities(abilitiesPath, raceName);

        /**
         * Associate the ability lists with the race asset
         */
        SerializedObject soRace = new SerializedObject(raceAsset);
        soRace.FindProperty("nexusAbilities").objectReferenceValue = nexusAL;
        soRace.FindProperty("barrackAbilities").objectReferenceValue = barrackAL;
        soRace.FindProperty("towerAbilities").objectReferenceValue = towerAL;

        soRace.ApplyModifiedProperties();
    }

    /// <summary>
    /// Create the NexusAbilities for the race
    /// </summary>
    /// <param name="abilityFolder">The ability folder path</param>
    /// <param name="raceName">the race name</param>
    /// <returns>The Nexus Ability List to associate to the Race asset</returns>
    private static AbilityList CreateNexusAbilities(string abilityFolder, string raceName)
    {
        AbilityList nexusAL = CreateAbilityList(abilityFolder, raceName, NEXUS_ABILITIES_FOLDER_NAME, NEXUS_ABILITY_LIST_NAME);

        return nexusAL;
    }

    /// <summary>
    /// Create the BarrackAbilities for the race
    /// </summary>
    /// <param name="abilityFolder">The ability folder path</param>
    /// <param name="raceName">the race name</param>
    /// <returns>The Barrack Ability List to associate to the Race asset</returns>
    private static AbilityList CreateBarrackAbilities(string abilityFolder, string raceName)
    {
        AbilityList barrackAL = CreateAbilityList(abilityFolder, raceName, BARRACK_ABILITIES_FOLDER_NAME, BARRACK_ABILITY_LIST_NAME);

        return barrackAL;
    }

    /// <summary>
    /// Create the TowerAbilities for the race
    /// </summary>
    /// <param name="abilityFolder">The ability folder path</param>
    /// <param name="raceName">the race name</param>
    /// <returns>The Tower Ability List to associate to the Race asset</returns>
    private static AbilityList CreateTowerAbilities(string abilityFolder, string raceName)
    {
        AbilityList towerAL = CreateAbilityList(abilityFolder, raceName, TOWER_ABILITIES_FOLDER_NAME, TOWER_ABILITY_LIST_NAME);

        return towerAL;
    }

    #endregion

    /// <summary>
    /// create the AbilityList Object and its associated folder
    /// </summary>
    /// <param name="abilityFolder">The path of the ability folder</param>
    /// <param name="raceName">the name of the race</param>
    /// <param name="abilityListFolderName">the name of the AbilityList folder to create</param>
    /// <param name="abilityListObjectName">the name of the AbiltiyList object to create</param>
    /// <returns>The ability list object created </returns>
    private static AbilityList CreateAbilityList(string abilityFolder, string raceName, string abilityListFolderName, string abilityListObjectName)
    {
        /**
         * Create the folder for the ability list and retrieve its path using the folder GUID
         */
        string abilityListGUID = AssetDatabase.CreateFolder(abilityFolder, abilityListFolderName);
        string abilityListPath = AssetDatabase.GUIDToAssetPath(abilityListGUID);

        /**
         * Create the AbilityList object and initialize its properties
         */
        AbilityList al = ScriptableObject.CreateInstance<AbilityList>();
        al.Init();
        
        //create the actual ability list asset using the initialized object
        AssetDatabase.CreateAsset(al, abilityListPath + "/" + raceName + abilityListObjectName + FILE_EXT);

        return al;
    }
}