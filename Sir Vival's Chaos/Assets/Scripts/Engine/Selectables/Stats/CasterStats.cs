using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterStats : Stats {

    [SerializeField]
    private Mana mana;

    public Mana Mana
    {
        get
        {
            return mana;
        }
    }

}
