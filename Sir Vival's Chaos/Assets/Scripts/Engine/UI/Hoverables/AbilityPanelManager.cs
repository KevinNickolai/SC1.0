using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPanelManager : MonoBehaviour {

    public static AbilityPanelManager instance;

    private AbilityPane[] panes;

	// Use this for initialization
	void Start () {

        //if the static AbilityPanelManager instance is not null and isn't this object, destroy itself
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        //set the static instance
        instance = this;

        //create the array of panes
        panes = new AbilityPane[AbilityList.MAX_SIZE];

        //index of the pane in the actual game scene
        int paneNum;

        //initialize array of panes
        for(int i = 0; i < AbilityList.MAX_SIZE; ++i)
        {
            paneNum = i + 1;
            panes[i] = GameObject.Find("Ability " + paneNum + " Pane").GetComponent<AbilityPane>();
        }
	}
	
    /// <summary>
    /// Get the instance of the AbilityPanelManager
    /// </summary>
    /// <returns>instance of AbilityPanelManager</returns>
    public static AbilityPanelManager GetInstance()
    {
        if(instance == null)
        {
            throw new System.Exception("AbilityPanelManager instance does not exist");
        }
        return instance;
    }

    public void SetPanes(AbilityList abilities)
    {
        for(int i = 0; i < AbilityList.MAX_SIZE; ++i)
        {
            panes[i].Ability = abilities[i];
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
