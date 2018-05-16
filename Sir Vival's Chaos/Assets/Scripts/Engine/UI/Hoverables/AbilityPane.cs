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

    protected override void OnMouseEnter()
    {
        //Display tooltip
        //Debug.Log("Display Tooltip");
        if (ability == null)
        {
            UIController.GetInstance().DisplayTooltip("Null Ability on: " + gameObject.name);
        }
        else
        {
            UIController.GetInstance().DisplayTooltip(ability.Tooltip);
        }
    }

    private void OnMouseDown()
    {
        if(ability != null && ability.IsActivatable)
        {
            ((ActivatedAbility)ability).Activate();
        }
    }
}
