using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pane : Hoverable {

    /// <summary>
    /// color for a faded pane
    /// </summary>
    public static Color FADED_PANE = new Color(1f, 1f, 1f, .4f);

    /// <summary>
    /// color for a solid pane
    /// </summary>
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

    /// <summary>
    /// The ability displayed by the Pane
    /// </summary>
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

    /// <summary>
    /// Set the sprite for the Pane in the UI
    /// </summary>
    protected virtual void SetSprite()
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
            SetBasicSprite();
        }
    }

    /// <summary>
    /// Set a sprite that will always appear active
    /// </summary>
    protected void SetActiveSprite()
    {
        uiImage.color = SOLID_PANE; /**ability.IsActivatable*/// ? SOLID_PANE : FADED_PANE;
        uiImage.sprite = ability.Sprite ? ability.Sprite : startSprite;
    }

    /// <summary>
    /// Set a sprite that will appear active or inactive based on the Pane's ability's activation properties
    /// </summary>
    protected void SetActiveOrInactiveSprite()
    {
        uiImage.color = ability.IsActivatable ? SOLID_PANE : FADED_PANE;
        uiImage.sprite = ability.Sprite ? ability.Sprite : startSprite;
    }

    /// <summary>
    /// Set a sprite that will always appear inactive
    /// </summary>
    protected void SetInactiveSprite()
    {
        uiImage.color = FADED_PANE;
        uiImage.sprite = ability.Sprite ? ability.Sprite : startSprite;
    }

    /// <summary>
    /// Sets a basic sprite to the pane
    /// </summary>
    protected void SetBasicSprite()
    {
        uiImage.color = FADED_PANE;
        uiImage.sprite = startSprite;
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

    /// <summary>
    /// Redraw the Pane
    /// </summary>
    public void Redraw()
    {
        this.SetSprite();
    }
}
