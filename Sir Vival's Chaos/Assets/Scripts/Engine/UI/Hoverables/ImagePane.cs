using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePane : Hoverable {

    protected override void OnMouseEnter()
    {
        //Display tooltip
        //Debug.Log("Display Tooltip");

        UIController.GetInstance().DisplayTooltip("Hovering over: " + gameObject.name);
    }
}
