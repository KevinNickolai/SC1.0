using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPane : MonoBehaviour {

    private void OnMouseDown()
    {
        Debug.Log("Clicked Ability");
    }

    private void OnMouseEnter()
    {
        //Display tooltip
        Debug.Log("Display Tooltip");
    }

    private void OnMouseExit()
    {
        Debug.Log("Hiding Tooltip");
    }
}
