using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    UIController uiCont;

    float time = 0;
    public float GameTime
    {
        get
        {
            return time;
        }
    }

	// Use this for initialization
	void Start () {
        uiCont = gameObject.AddComponent<UIController>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

}
