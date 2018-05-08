using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    /// <summary>
    /// The name of the building
    /// </summary>
    private new string name; //< the new keyword distinguishes Building::name from Object::name, since that's not the intended inheiritance.

    public string Name
    {
        get
        {
            return name;
        }
    }

    private void Start()
    {
        name = gameObject.transform.name;
    }

    /// <summary>
    /// Handle event when the mouse is pressed on this Building
    /// </summary>
    protected void OnMouseDown()
    {
        //Display information for this Building
        GameObject.FindObjectOfType<UIController>().DisplayBuildingInfo(this);
    }

    /// <summary>
    /// When the mouse hovers over the collider of the building, display the outline
    /// </summary>
    protected void OnMouseEnter()
    {
    }

    /// <summary>
    /// When the mouse stops hovering over the collider of the building, remove the outline
    /// </summary>
    protected void OnMouseExit()
    {
        
    }
}
