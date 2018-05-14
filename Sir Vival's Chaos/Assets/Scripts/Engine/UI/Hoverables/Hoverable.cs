using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour {

    private void OnMouseDown()
    {
        Debug.Log("Clicked Ability");
    }

    private void OnMouseEnter()
    {
        //Display tooltip
        Debug.Log("Display Tooltip");

        UIController.GetInstance().DisplayTooltip("Hovering over: " + gameObject.name);
    }

    private void OnMouseExit()
    {
        Debug.Log("Hiding Tooltip");

        UIController.GetInstance().HideTooltip();
    }

}
