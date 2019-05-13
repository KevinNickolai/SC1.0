using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes a Hoverable UI element
/// </summary>
public abstract class Hoverable : MonoBehaviour {

    protected virtual void OnMouseDown()
    {
        Debug.Log("Clicked Hoverable");
    }

    /// <summary>
    /// Display the tooltip for the hoverable object
    /// </summary>
    protected abstract void OnMouseEnter();
    

    private void OnMouseExit()
    {
        //Debug.Log("Hiding Tooltip");

        UIController.GetInstance().HideTooltip();
    }

}
