using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPane : Hoverable {
    private Ability ability;

    public Ability Ability
    {
        get
        {
            return ability;
        }

        set
        {
            ability = value;
        }
    }

    

}
