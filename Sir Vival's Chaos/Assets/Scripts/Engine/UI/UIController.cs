using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private static UIController instance;

    #region Constant Text Object names
    private const string TIMER_NAME = "Timer";

    private const string INFO_NAME = "InfoName";
    private const string INFO_LEVEL = "InfoLevel";

    private const string STATS_PANEL = "Stats Panel";
    private const string ATTR_PANEL = "Attributes Panel";

    private const string DEF_LEVEL = "Defense Level";
    private const string ATK_LEVEL = "Attack Level";

    private const string ARMOR = "Defense Armor";
    private const string DAMAGE = "Attack Damage";

    private const string ATTACK_IMAGE = "Attack Image";
    private const string DEFENSE_IMAGE = "Defense Image";

    private const string STRENGTH = "Strength";
    private const string AGILITY = "Agility";
    private const string INTELLIGENCE = "Intelligence";
    #endregion

    #region Text and Image variables
    private Text timerText;

    private Text infoNameText;
    private Text infoLevelText;

    private Text dmg;
    private Text armor;

    private Image dmgType;
    private Image armorType;

    private Text str;
    private Text agi;
    private Text intel;

    private Text atkLevel;
    private Text defLevel;
    #endregion

    /// <summary>
    /// The panel displaying stats information
    /// </summary>
    private GameObject statsPanel;

    /// <summary>
    /// The panel displaying attribute information for heroes
    /// </summary>
    private GameObject attrPanel;

    /// <summary>
    /// The panel displaying the tooltip
    /// </summary>
    private TooltipManager tooltipManager;

    GameController gc;

    IDescribable objDisplayed;

    /// <summary>
    /// Get the instance of the UIController in the scene
    /// </summary>
    /// <returns>instance of UIController</returns>
    public static UIController GetInstance()
    {
        if (instance == null)
        {
            Debug.Log("UIController instance not initialized");
        }

        return instance;
    }

	// Use this for initialization
	void Start () {
        //relation to GameController
        gc = GameObject.FindObjectOfType<GameController>();

        //initialize the AbilityPanelManager
        gameObject.AddComponent<AbilityPanelManager>();
        tooltipManager = gameObject.AddComponent<TooltipManager>();

        instance = this;

        statsPanel = GameObject.Find(STATS_PANEL);
        attrPanel = GameObject.Find(ATTR_PANEL);

        //timer text object
        timerText = GameObject.Find(TIMER_NAME).GetComponent<Text>();

        //information panel name text object
        infoNameText = GameObject.Find(INFO_NAME).GetComponent<Text>();

        //information panel level text object
        infoLevelText = GameObject.Find(INFO_LEVEL).GetComponent<Text>();

        //damage text object
        dmg = GameObject.Find(DAMAGE).GetComponent<Text>();

        //armor text object
        armor = GameObject.Find(ARMOR).GetComponent<Text>();

        //attribute text objects
        str = GameObject.Find(STRENGTH).GetComponent<Text>();
        agi = GameObject.Find(AGILITY).GetComponent<Text>();
        intel = GameObject.Find(INTELLIGENCE).GetComponent<Text>();



        dmgType = GameObject.Find(ATTACK_IMAGE).GetComponent<Image>();
        armorType = GameObject.Find(DEFENSE_IMAGE).GetComponent<Image>();

        //attack/defense level text objects
        atkLevel = GameObject.Find(ATK_LEVEL).GetComponent<Text>();
        defLevel = GameObject.Find(DEF_LEVEL).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        timerText.text = convertTime(gc.GameTime);
	}

    #region Displaying Information for objects
  
    /// <summary>
    /// Display information of an IDescribable object
    /// </summary>
    /// <param name="obj">the object to describe</param>
    public void DisplayInfo(IDescribable obj)
    {
        //clear all prior information
        ClearInfo();

        objDisplayed = obj;

        //set text for the object's name
        infoNameText.text = obj.Name;

        //redisplay the stats panel
        statsPanel.SetActive(true);

        //set text damage for the object
        dmg.text = obj.MinDamage + " - " + obj.MaxDamage;

        //set text armor for the object
        armor.text = obj.Armor.ToString();

        //set sprites for the Damage & Armor types
        dmgType.sprite = obj.DamageType.SpriteOfType;
        armorType.sprite = obj.ArmorType.SpriteOfType;

        /**
        //set text level of the attack/defense levels
        atkLevel.text = obj.
            Player.
            Race.
            GetAttackUpgrade(
            obj.AttackUpgradeType
            )
            .Level.ToString();
        defLevel.text = obj.Player.Race.ArmorUpgrade.Level.ToString();*/
    }

    /// <summary>
    /// Display information of an ILevelable object
    /// </summary>
    /// <param name="obj">the object to describe</param>
    public void DisplayInfo(ILevelableObject obj)
    {
        //display base object information
        DisplayInfo((IDescribable)obj);

        //display the level of the object
        infoLevelText.text = "Level " + obj.Level;
    }

    /// <summary>
    /// Display information of an IAttributable object
    /// </summary>
    /// <param name="obj">the object to describe</param>
    public void DisplayInfo(IAttributable obj)
    {
        //display base object information
        DisplayInfo((ILevelableObject)obj);

        //redisplay the attributes panel
        attrPanel.SetActive(true);

        str.text = obj.Strength.ToString();
        agi.text = obj.Agility.ToString();
        intel.text = obj.Intelligence.ToString();
    }

    /// <summary>
    /// Redraw the object being displayed on the UI
    /// </summary>
    public void Redraw()
    {
        /**
         * Display the object based on its lowest heirarchal type
         */
        if(objDisplayed is IAttributable)
        {
            DisplayInfo((IAttributable)objDisplayed);
        }
        else if(objDisplayed is ILevelableObject)
        {
            DisplayInfo((ILevelableObject)objDisplayed);
        }
        else
        {
            DisplayInfo(objDisplayed);
        }
    }

    #endregion

    /// <summary>
    /// Clear information on the UI
    /// </summary>
    public void ClearInfo()
    {
        infoNameText.text = "";
        infoLevelText.text = "";
        statsPanel.SetActive(false);
        attrPanel.SetActive(false);

        objDisplayed = null;
    }

    /// <summary>
    /// Convert the ingame time to a string for display
    /// </summary>
    /// <param name="time">time to convert</param>
    /// <returns></returns>
    private string convertTime(float time)
    {
        string t = "";
        int minutes = (int)(time / 60);
        int seconds = ((int)time % 60);

        //time in the (minutes):(seconds) format
        //ternary operator used to add extra 0 on the seconds counter
        //to make it appear as this example: "0:09" instead of "0:9"
        t += minutes + ":" + (seconds < 10 ? "0" : "") + ((int)time % 60);
        return t;
    }

    /// <summary>
    /// Display a tooltip
    /// </summary>
    /// <param name="tt">the tooltip string we want to display</param>
    public void DisplayTooltip(string tt)
    {
        tooltipManager.DisplayTooltip(tt);
    }

    /// <summary>
    /// Display a tooltip
    /// </summary>
    /// <param name="tt">the Tooltip to display</param>
    public void DisplayTooltip(Tooltip tt)
    {
        tooltipManager.DisplayTooltip(tt);
    }

    public void DisplayDamageTypeTooltip()
    {
        DisplayTooltip(objDisplayed.DamageType.GetMatchupTooltip());
    }

    public void DisplayArmorTypeTooltip()
    {
        DisplayTooltip(objDisplayed.ArmorType.GetMatchupTooltip());
    }


    /// <summary>
    /// Hide the tooltip
    /// </summary>
    public void HideTooltip()
    {
        tooltipManager.HideTooltip();
    }

    /// <summary>
    /// Set the ability panes for the currently selected object
    /// </summary>
    /// <param name="list">The list of abilities associated with the object</param>
    public void SetAbilityPanes(AbilityList list)
    {
        AbilityPanelManager.GetInstance().SetPanes(list);
    }
}
