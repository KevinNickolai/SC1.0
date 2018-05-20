﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a tooltip for some object.
/// </summary>
public abstract class Tooltip : ScriptableObject {
    
    /// <summary>
    /// Title of the Tooltip
    /// </summary>
    [SerializeField]
    private string title = "*No Title*";

    /// <summary>
    /// The sections the tooltip is divided into
    /// </summary>
    [SerializeField]
    private List<TooltipSection> sections;

    /// <summary>
    /// The title of the tooltip
    /// </summary>
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

    /// <summary>
    /// Get the text formatted for display to show for the tooltip
    /// </summary>
    /// <returns>string of formatted text to display</returns>
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