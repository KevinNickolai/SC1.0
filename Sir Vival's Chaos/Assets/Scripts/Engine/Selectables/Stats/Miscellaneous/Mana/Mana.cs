using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMana", menuName = "Stats/Misc/Mana")]
public class Mana : ScriptableObject{

    [SerializeField]
    private IntReference maxMana;

    public int MaxMana
    {
        get
        {
            return maxMana.Value;
        }
    }


}
