using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip {

    private List<TooltipSection> sections;

    public Tooltip()
    {
        sections = new List<TooltipSection>();
    }

    public string GetDisplayText()
    {
        string dispStr = "";
        foreach(TooltipSection tts in sections)
        {
            dispStr += tts.Display() + '\n';
        }

        return dispStr;
    }

}