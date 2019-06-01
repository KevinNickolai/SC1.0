using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour {

    private const string TOOLTIP_TITLE = "Tooltip Title";
    private const string TOOLTIP_BODY = "Tooltip Body";
    private const string TOOLTIP_COST = "Tooltip Cost";
    private const string TOOLTIP_COST_IMAGE = "Tooltip Cost Image";
    private const string TT_PANEL = "Tooltip Panel";
    private const string TOOLTIP_TIME = "Tooltip Time";

    private Text tooltipBody;
    private Text tooltipTitle;
    private Text tooltipTimeText;
    private Text tooltipCost;
    private Image tooltipCostImage;

    private GameObject tooltipTime;

    //C5A626C8 for gold color
    private Color gold = new Color(197, 166, 38, 200);

    //2683C5C8 for blue color
    private Color manaBlue = new Color(38, 131, 197, 200);

    /// <summary>
    /// The panel displaying the tooltip
    /// </summary>
    private GameObject tooltipPanel;

    private 
    // Use this for initialization
    void Start () {
        //tooltip text object
        tooltipBody = GameObject.Find(TOOLTIP_BODY).GetComponent<Text>();

        tooltipTitle = GameObject.Find(TOOLTIP_TITLE).GetComponent<Text>();

        tooltipCost = GameObject.Find(TOOLTIP_COST).GetComponent<Text>();

        tooltipCostImage = GameObject.Find(TOOLTIP_COST_IMAGE).GetComponent<Image>();

        tooltipTime = GameObject.Find(TOOLTIP_TIME);

        tooltipTimeText = tooltipTime.GetComponent<Text>();

        //tooltip panel game object
        tooltipPanel = GameObject.Find(TT_PANEL);

    }

    public void DisplayTooltip(string tt)
    {
        ClearTooltip();
        tooltipPanel.SetActive(true);
        tooltipBody.text = tt;
    }

    public void DisplayTooltip(Tooltip tt)
    {
        ClearTooltip();
        tooltipPanel.SetActive(true);

        tooltipTitle.text = tt.Title;
        tooltipBody.text = tt.GetDisplayText();
    }

    /// <summary>
    /// Hide the tooltip panel
    /// </summary>
    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }

    private void ClearTooltip()
    {
        tooltipTitle.text = "";
        tooltipCost.text = "";
        tooltipCostImage.color = Color.clear;
        tooltipTime.SetActive(false);
    }
}
