using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLineTooltipSection : TooltipSection {

    /// <summary>
    /// MultiLineTooltipSection constructor
    /// </summary>
    /// <param name="header">the header for the TooltipSection</param>
    public MultiLineTooltipSection(string header) : base(header) { }

    /// <summary>
    /// MultiLineTooltipSection constructor
    /// </summary>
    /// <param name="header">the header for the TooltipSection</param>
    /// <param name="body">the body for the TooltipSection</param>
    public MultiLineTooltipSection(string header, string body) : base(header, body) { }

    /// <summary>
    /// Add a line to the body of the TooltipSection
    /// </summary>
    /// <param name="line">the string to add to the body, on a new line</param>
    public void AddLine(string line/**, string color */)
    {
        Body = Body += "\n" + line;
    }
}
