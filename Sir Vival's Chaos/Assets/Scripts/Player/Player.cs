using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// The player's race
    /// </summary>
    private Race race;

    private int gold;

    public int Gold
    {
        get
        {
            return gold;
        }
    }

    /// <summary>
    /// The player's race
    /// </summary>
    public Race Race
    {
        get
        {
            return race;
        }
    }

    public void Start()
    {
        //add Player input controls to the player
        gameObject.AddComponent<InputControls>();
    }


    
}
