using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IDescribable {

    /// <summary>
    /// The name of the unit
    /// </summary>
    private new string name;

    /// <summary>
    /// accessor for name
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }
    }
	
    void Start()
    {
        name = gameObject.transform.name;
    }

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);
    }
}
