using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTooltipSection", menuName = "Tooltips/TooltipSections/TooltipSection", order = 1)]
public class TooltipSection : ScriptableObject{

    /// <summary>
    /// Constant for the header color
    /// </summary>
    private static string HEADER_COLOR = "#ffa500ff";

    /// <summary>
    /// header of the tooltip section
    /// </summary>
    private string header;

    /// <summary>
    /// body of the tooltip section
    /// </summary>
    [SerializeField][TextArea]
    private string body;

    /// <summary>
    /// Header of the tooltip section
    /// </summary>
    public string Header
    {
        get
        {
            return header;
        }
    }

    /// <summary>
    /// Body for the tooltip section
    /// </summary>
    public string Body
    {
        get
        {
            return body;
        }
    }

    protected void SetHeader(string header)
    {
        this.header = header;
    }

    /// <summary>
    /// Display the tooltip section in a formatted way
    /// </summary>
    /// <returns></returns>
    public string Display()
    {
        //display the header, colored a specific way
        string dispStr =
            "<color=" + HEADER_COLOR + ">" +
            header +
            ":</color> " +
            body;

        return dispStr;
    }
}
