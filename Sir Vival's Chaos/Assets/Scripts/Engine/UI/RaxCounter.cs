using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaxCounter : MonoBehaviour {

    Barrack rax;

	// Use this for initialization
	void Start () {

	}

    public void init()
    {
        //get the barrack this RaxCounter is attached to
        rax = gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>().gameObject.GetComponent<Barrack>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
