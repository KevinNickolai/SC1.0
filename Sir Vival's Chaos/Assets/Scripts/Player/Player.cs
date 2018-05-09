using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public void Start()
    {
        //add Player input controls to the player
        gameObject.AddComponent<InputControls>();
    }


    
}
