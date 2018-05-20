using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit, IAttributable {

    public const string hero = "Prefabs/hero";

    int str, agi, intel, level = 1;

    public int Strength
    {
        get
        {
            return str;
        }

        set
        {
            str = value;
        }
    }

    public int Agility
    {
        get
        {
            return agi;
        }

        set
        {
            agi = value;
        }
    }

    public int Intelligence
    {
        get
        {
            return intel;
        }

        set
        {
            intel = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    public void LevelUp()
    {
        ++level;
    }

    protected override void OnMouseDown()
    {
        GameObject.FindObjectOfType<UIController>().DisplayInfo(this);
    }
}
