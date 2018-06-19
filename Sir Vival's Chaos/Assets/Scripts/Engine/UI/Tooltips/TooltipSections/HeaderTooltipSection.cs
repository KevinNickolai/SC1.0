using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderTooltipSection : TooltipSection {

    /// <summary>
    /// Constant for the header color
    /// </summary>
    private static string HEADER_COLOR = "#ffa500ff";

    /// <summary>
    /// header of the tooltip section
    /// </summary>
    [SerializeField]
    [ReadOnly]
    private string header;

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

    protected void SetHeader(string header)
    {
        this.header = header;
    }

    /// <summary>
    /// Display the HeaderTooltipSection
    /// </summary>
    /// <returns></returns>
    public virtual string Display()
    {
        //display the header, colored a specific way
        string dispStr =
            "<color=" + HEADER_COLOR + ">" +
            header +
            ":</color> ";

        //return the displayed header and the base TooltipSection Display string
        return dispStr + base.Display();
    }
}
