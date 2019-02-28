using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTooltipSection", menuName = "Tooltips/TooltipSections/TooltipSection", order = 1)]
public class TooltipSection : ScriptableObject {

    /// <summary>
    /// body of the tooltip section
    /// </summary>
    [SerializeField][TextArea]
    private string body;

    public void Init(string b)
    {
        body = b;
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

    /// <summary>
    /// Display the tooltip section in a formatted way
    /// </summary>
    /// <returns>string of text to display for the tooltip</returns>
    public virtual string Display()
    {
        return body + "\n";
    }
}
