using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTrackerUI {

    private IntReference currentHP;

    private Hitpoints maxHP;

    private Image healthBar;

    private static GameObject hpGO = Resources.Load<GameObject>("Prefabs/UIPrefabs/HealthBar");

    public HPTrackerUI(GameObject addHPBar, Hitpoints max)
    {
        maxHP = max;
        currentHP = ScriptableObject.CreateInstance<IntReference>();
        currentHP.SetConstant(maxHP.MaxHP);


        

        healthBar = GameObject.Instantiate<GameObject>(
            hpGO,
            addHPBar.transform.position + new Vector3(0, 10, 0),
            Quaternion.Euler(new Vector3(30,0,0)),
            addHPBar.transform
            ).transform.GetChild(0).GetComponent<Image>();
    }


}
