using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip {

    private List<TooltipSection> sections;

    private string title = "*No Title*";

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public Tooltip()
    {
        sections = new List<TooltipSection>();
    }

    public string GetDisplayText()
    {
        string dispStr = title + "\n\n";
        foreach(TooltipSection tts in sections)
        {
            dispStr += tts.Display() + '\n';
        }

        return dispStr;
    }

    public void AddSection(TooltipSection section)
    {
        sections.Add(section);
    }

    /// <summary>
    /// Get a section of the Tooltip to modify based on the header
    /// </summary>
    /// <param name="header">Header of the section to get</param>
    /// <returns>TooltipSection with the matching header, null if no TooltipSection in the Tooltip has the matching header</returns>
    public TooltipSection GetSection(string header)
    {
        foreach(TooltipSection tts in sections)
        {
            if(tts.Header == header)
            {
                return tts;
            }
        }

        Debug.LogError("No Header matching \"" + header + "\" in Tooltip.");
        return null;
    }
}