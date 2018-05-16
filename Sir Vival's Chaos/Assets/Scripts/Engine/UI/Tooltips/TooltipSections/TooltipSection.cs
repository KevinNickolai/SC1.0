using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSection {

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

        set
        {
            body = value;
        }
    }

    /// <summary>
    /// Tooltip Section constructor
    /// </summary>
    /// <param name="header">tooltip header for this section</param>
    /// <param name="body">tooltip body for this section</param>
    public TooltipSection(string header, string body)
    {
        Init(header,body);
    }

    /// <summary>
    /// Tooltip Section constructor
    /// </summary>
    /// <param name="header">tooltip header for this section</param>
    public TooltipSection(string header)
    {
        Init(header);
    }

    /// <summary>
    /// Initialize the Tooltip section
    /// </summary>
    /// <param name="header">the header for the TooltipSection</param>
    private void Init(string header,string body = "*Empty Body*")
    {
        this.header = header;
        this.body = body;
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
