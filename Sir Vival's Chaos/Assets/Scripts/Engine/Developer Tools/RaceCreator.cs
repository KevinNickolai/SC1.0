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

    /**
     * Abilities Folders
     */
    private static string NEXUS_ABILITIES_FOLDER_NAME = "NexusAbilities";
    private static string BARRACK_ABILITIES_FOLDER_NAME = "BarrackAbilities";
    private static string TOWER_ABILITIES_FOLDER_NAME = "TowerAbilities";
    private static string ABILITIES_FOLDER_NAME = "Abilities";
    private static string INACTIVE_ABILITIES_FOLDER_NAME = "InactiveAbilities";
    private static string LEVEL_ABILITIES_FOLDER_NAME = "LevelAbilities";
    private static string DESCRIPTOR_ABILITIES_FOLDER_NAME = "DescriptorAbilities";

    /**
     * Upgrades Folders
     */
    private static string UPGRADES_FOLDER_NAME = "Upgrades";
    private static string AUX_UPGRS_FOLDER_NAME = "AuxiliaryUpgrades";
    #endregion

    /**
     * Note that for file distinction between different races, these
     * string names for assets should be prefixed in code by the 
     * raceName passed in when creating a race.
     */
    #region constant string names for assets

    /**
     * Ability Assets
     */
    private static string NEXUS_ABILITY_LIST_NAME = "NexusAbilities";
    private static string BARRACK_ABILITY_LIST_NAME = "BarrackAbilities";
    private static string TOWER_ABILITY_LIST_NAME = "TowerAbilities";
    private static string RACE_DESCRIPTOR_ASSET_NAME = "RaceDescription";
    private static string LEVEL_ABILITY_ASSET_NAME = "LevelAbility";

    private static string NEXUS_ASSET_NAME = "Nexus";
    private static string BARRACK_ASSET_NAME = "Barrack";

    /**
     * Upgrade Assets
     */
    private static string MELEE_ASSET_NAME = "Melee";
    private static string GATE_ASSET_NAME = "Gate";
    private static string MAGE_ASSET_NAME = "Mage";
    private static string ARMOR_ASSET_NAME = "Armor";
    private static string FORT_ASSET_NAME = "Fort";
    private static string UPGRADE_SUFFIX = "Upgrade";
    private static string AUXILIARY_ASSET_PREFIX = "Aux";
    #endregion
    
    /// <summary>
    /// The file extension to add to the end of assets
    /// </summary>
    private static string FILE_EXT = ".asset";

    /// <summary>
    /// Create the file for the new race
    /// </summary>
    /// <param name="raceName"></param>
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

        Race raceAsset = CreateRaceAsset(baseRaceFolder, raceName);

        CreateAbilities(baseRaceFolder,raceName, raceAsset);
        //CreateUnits();
        CreateUpgrades(baseRaceFolder, raceName, raceAsset);
    }

    /// <summary>
    /// create the race asset and any assets added to the race asset
    /// </summary>
    /// <param name="baseFolder">the folder to put the race asset in</param>
    /// <param name="raceName">the name of the race</param>
    /// <returns>The Race Asset created</returns>
    private static Race CreateRaceAsset(string baseFolder, string raceName)
    {
        //the asset path for the Race asset file
        string raceAssetPath = baseFolder + "/" + raceName + FILE_EXT;

        //create the Race object for the race
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<Race>(), raceAssetPath);

        //create a string reference to associate to the Race's name
        StringReference srName = ScriptableObject.CreateInstance<StringReference>();
        srName.name = (raceName + "RaceName");

        //The string reference must be first added to the Race Asset to allow for the setting of the name property of the race to the asset we're adding to the race asset
        AssetDatabase.AddObjectToAsset(srName, raceAssetPath);

        //reimport the asset to show the added asset
        AssetDatabase.ImportAsset(raceAssetPath);

        Race race = (Race)AssetDatabase.LoadAssetAtPath(raceAssetPath, typeof(Race));

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
    private static void CreateAbilities(string baseFolder, string raceName, Race raceAsset)
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
        /**
         * Create the folder for the ability list and retrieve its path using the folder GUID
         */
        string abilityListGUID = AssetDatabase.CreateFolder(abilityFolder, NEXUS_ABILITIES_FOLDER_NAME);
        string abilityListPath = AssetDatabase.GUIDToAssetPath(abilityListGUID);

        Ability[] list = new Ability[AbilityList.MAX_SIZE];

        /**
         * Create the abilities and fill the NexusAbilityList with them
         */
        string descriptorFolderGUID = AssetDatabase.CreateFolder(abilityListPath, DESCRIPTOR_ABILITIES_FOLDER_NAME);
        string descriptorFolderPath = AssetDatabase.GUIDToAssetPath(descriptorFolderGUID);

        list[NexusAbilityList.RACE_DESCRIPTOR] = CreateAbility<InactiveAbility>(descriptorFolderPath, raceName, RACE_DESCRIPTOR_ASSET_NAME);

        string levelAbilitiesFolderGUID = AssetDatabase.CreateFolder(abilityListPath, LEVEL_ABILITIES_FOLDER_NAME);
        string levelAbilitiesFolderPath = AssetDatabase.GUIDToAssetPath(levelAbilitiesFolderGUID);

        list[NexusAbilityList.MAGE_UPGRADE] = CreateAbility<LevelAbility>(levelAbilitiesFolderPath, raceName, MAGE_ASSET_NAME + LEVEL_ABILITY_ASSET_NAME);

        /**
         * list[2] goes here
         */

        list[NexusAbilityList.BUILDING_UPGRADE] = CreateAbility<LevelAbility>(levelAbilitiesFolderPath, raceName, NEXUS_ASSET_NAME + LEVEL_ABILITY_ASSET_NAME);

        list[NexusAbilityList.MELEE_UPGRADE] = CreateAbility<LevelAbility>(levelAbilitiesFolderPath, raceName, MELEE_ASSET_NAME + LEVEL_ABILITY_ASSET_NAME);

        list[NexusAbilityList.RANGE_UPGRADE] = CreateAbility<LevelAbility>(levelAbilitiesFolderPath, raceName, GATE_ASSET_NAME + LEVEL_ABILITY_ASSET_NAME);

        AbilityList nexusAL = CreateAbilityList(abilityListPath, raceName, NEXUS_ABILITY_LIST_NAME, list);


        
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
        /**
         * Create the folder for the ability list and retrieve its path using the folder GUID
         */
        string abilityListGUID = AssetDatabase.CreateFolder(abilityFolder, BARRACK_ABILITIES_FOLDER_NAME);
        string abilityListPath = AssetDatabase.GUIDToAssetPath(abilityListGUID);

        AbilityList barrackAL = CreateAbilityList(abilityListPath, raceName, BARRACK_ABILITY_LIST_NAME);

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
        /**
         * Create the folder for the ability list and retrieve its path using the folder GUID
         */
        string abilityListGUID = AssetDatabase.CreateFolder(abilityFolder, TOWER_ABILITIES_FOLDER_NAME);
        string abilityListPath = AssetDatabase.GUIDToAssetPath(abilityListGUID);

        AbilityList towerAL = CreateAbilityList(abilityListPath, raceName, TOWER_ABILITY_LIST_NAME);

        return towerAL;
    }

    /// <summary>
    /// create the AbilityList Object and its associated folder
    /// </summary>
    /// <param name="abilityFolder">The path of the ability folder</param>
    /// <param name="raceName">the name of the race</param>
    /// <param name="abilityListFolderName">the name of the AbilityList folder to create</param>
    /// <param name="abilityListObjectName">the name of the AbiltiyList object to create</param>
    /// <returns>The ability list object created </returns>
    private static AbilityList CreateAbilityList(string abilityListFolder, string raceName, string abilityListObjectName, Ability[] list = null)
    {
        /**
         * Create the AbilityList object and initialize its properties
         */
        AbilityList al = ScriptableObject.CreateInstance<AbilityList>();
        al.Init(list);

        //create the actual ability list asset using the initialized object
        AssetDatabase.CreateAsset(al, abilityListFolder + "/" + raceName + abilityListObjectName + FILE_EXT);

        return al;
    }

    /// <summary>
    /// Create an ability to add to an AbilityList
    /// </summary>
    /// <typeparam name="AbilityType">The type of ability to create</typeparam>
    /// <param name="abilityFolder">the name of the ability folder to create the ability in</param>
    /// <param name="raceName">the name of the race</param>
    /// <param name="abilityName">the name of the ability to create</param>
    /// <returns></returns>
    private static AbilityType CreateAbility<AbilityType>(string abilityFolder, string raceName, string abilityName) where AbilityType : Ability
    {
        AbilityType ability = ScriptableObject.CreateInstance<AbilityType>();

        AssetDatabase.CreateAsset(ability, abilityFolder + "/" + abilityName + FILE_EXT);

        return ability;
    }

    #endregion

    #region CreateUpgrades Functions

    /// <summary>
    /// Create the race upgrades
    /// </summary>
    /// <param name="baseFolder">base folder path to create all upgrades in</param>
    /// <param name="raceName">the name of the race being created</param>
    /// <param name="raceAsset">the race asset, used to create associations between the upgrades and the race</param>
    private static void CreateUpgrades(string baseFolder, string raceName, Race raceAsset)
    {
        string upgradesGUID = AssetDatabase.CreateFolder(baseFolder, UPGRADES_FOLDER_NAME);
        string upgradesPath = AssetDatabase.GUIDToAssetPath(upgradesGUID);

        MeleeUpgrade meleeUpgr = CreateUpgrade<MeleeUpgrade>(upgradesPath, raceName, MELEE_ASSET_NAME);
        GateUpgrade gateUpgr = CreateUpgrade<GateUpgrade>(upgradesPath, raceName, GATE_ASSET_NAME);
        MageUpgrade mageUpgr = CreateUpgrade<MageUpgrade>(upgradesPath, raceName, MAGE_ASSET_NAME);
        DefenseUpgrade armorUpgr = CreateUpgrade<DefenseUpgrade>(upgradesPath, raceName, ARMOR_ASSET_NAME);

        
        /**
         * Associate the upgrades with their respective type of upgrade
         */
        SerializedObject soRace = new SerializedObject(raceAsset);
        soRace.FindProperty("meleeUpgr").objectReferenceValue = meleeUpgr;
        soRace.FindProperty("gateUpgr").objectReferenceValue = gateUpgr;
        soRace.FindProperty("mageUpgr").objectReferenceValue = mageUpgr;
        soRace.FindProperty("armorUpgr").objectReferenceValue = armorUpgr;

        /**
         * Create the auxiliary upgrade array and fill it with empty auxiliary upgrades
         */
        soRace.FindProperty("auxUpgrs").arraySize = AuxUpgrade.MAX_AUX_UPGRADES;

        string auxGUID = AssetDatabase.CreateFolder(upgradesPath, AUX_UPGRS_FOLDER_NAME);
        string auxUpgrsPath = AssetDatabase.GUIDToAssetPath(auxGUID);

        for(int i = 0; i < AuxUpgrade.MAX_AUX_UPGRADES; ++i)
        {
            AuxUpgrade au = CreateUpgrade<AuxUpgrade>(auxUpgrsPath, raceName, AUXILIARY_ASSET_PREFIX + i);
            soRace.FindProperty("auxUpgrs").GetArrayElementAtIndex(i).objectReferenceValue = au;
        }

        soRace.ApplyModifiedProperties();
    }

    /// <summary>
    /// Create a specific type of upgrade
    /// </summary>
    /// <typeparam name="UpgrType">the type of the upgrade to create</typeparam>
    /// <param name="upgradesFolder">name of the folder to place the upgrade file in</param>
    /// <param name="raceName">the name of the race we're creating</param>
    /// <param name="upgradeType">the string associated with an upgrade type</param>
    /// <returns></returns>
    private static UpgrType CreateUpgrade<UpgrType>(string upgradesFolder, string raceName, string upgradeType) where UpgrType : Upgrade
    {
        UpgrType upgr = ScriptableObject.CreateInstance<UpgrType>();

        AssetDatabase.CreateAsset(upgr, upgradesFolder + "/" + raceName + upgradeType + UPGRADE_SUFFIX + FILE_EXT);

        return upgr;
    }

    #endregion

}