using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hoverable : MonoBehaviour {

    private void OnMouseDown()
    {
        Debug.Log("Clicked Ability");
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
