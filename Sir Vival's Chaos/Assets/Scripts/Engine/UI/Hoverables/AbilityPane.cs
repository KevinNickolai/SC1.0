using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPane : Hoverable {

    public static Color FADED_PANE = new Color(1f, 1f, 1f, .4f);
    public static Color SOLID_PANE = new Color(255f, 255f, 255f, 255f);
    private void Start()
    {
        uiImage = gameObject.GetComponent<Image>();
        startSprite = uiImage.sprite;
    }

    /// <summary>
    /// Temporary sprite used as a filler for null ability sprites
    /// </summary>
    private Sprite startSprite;

    /// <summary>
    /// the image associated with this AbilityPane
    /// </summary>
    private Image uiImage;

    /// <summary>
    /// the ability this AbilityPane is displaying
    /// </summary>
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
            SetSprite();
        }
    }


    private void SetSprite()
    {
        if (ability)
        {
            //set the image color based on the ability's activatable state.
            uiImage.color = ability.IsActivatable ? SOLID_PANE : FADED_PANE;

            //set the uiImage sprite to the ability sprite if it exists, or the starting ability pane sprite otherwise
            uiImage.sprite = ability.Sprite ? ability.Sprite : startSprite;
        }
        else
        {
            uiImage.color = FADED_PANE;
            uiImage.sprite = startSprite;
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
