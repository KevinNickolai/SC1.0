using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private const string TIMER_NAME = "Timer";
    private const string INFO_NAME = "InfoName";
    private const string INFO_LEVEL = "InfoLevel";
    private const string STATS_PANEL = "Stats Panel";


    private Text timerText;

    private Text infoNameText;
    private Text infoLevelText;
    private GameObject statsPanel;

    GameController gc;

	// Use this for initialization
	void Start () {
        //relation to GameController
        gc = GameObject.FindObjectOfType<GameController>();

        //timer text object
        timerText = (Text)GameObject.Find(TIMER_NAME).GetComponent("Text");

        //information panel name text object
        infoNameText = (Text)GameObject.Find(INFO_NAME).GetComponent("Text");
        infoLevelText = (Text)GameObject.Find(INFO_LEVEL).GetComponent("Text");

        statsPanel = GameObject.Find(STATS_PANEL);
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
        infoNameText.text = obj.Name;

        //clear unused text
        infoLevelText.text = "";
    }

    /// <summary>
    /// Display information of an ILevelable object
    /// </summary>
    /// <param name="obj">the object to describe</param>
    public void DisplayInfo(ILevelable obj)
    {
        //display base object information
        DisplayInfo((IDescribable)obj);

        //display the level of the object
        infoLevelText.text = "Level " + obj.Level;
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
}
