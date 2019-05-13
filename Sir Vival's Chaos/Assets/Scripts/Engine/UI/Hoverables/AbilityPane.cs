using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPane : Pane {

    protected override void SetSprite()
    {
        if (Ability)
        {
            if (Ability is LevelAbility && ((LevelAbility)Ability).Researching)
            {
                SetInactiveSprite();
            }
            else
            {
                SetActiveOrInactiveSprite();
            }
        }
        else
        {
            SetBasicSprite();
        }

    }

    /// <summary>
    /// Called when the user clicks the collider attached to GameObject the AbilityPane is on
    /// </summary>
    protected override void OnMouseDown()
    {
        //if a non-null, activatable ability is clicked, process the interaction
        if(Ability != null && Ability.IsActivatable)
        {
            //checking for associated costs of the ability
            if(Ability is CostedAbility)
            {

            }

            //activate the ability
            ((ActivatedAbility)Ability).Activate();

            Redraw();
        }
    }
}
