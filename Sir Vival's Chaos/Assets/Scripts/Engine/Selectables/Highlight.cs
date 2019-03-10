using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highlight : MonoBehaviour {

    public void ShowHighlight()
    {
        gameObject.SetActive(true);
    }

    public void HideHighlight()
    {
        gameObject.SetActive(false);
    }
}
