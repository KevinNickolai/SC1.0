using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResearchPane : Pane {

    [SerializeField]
    private int queuePosition = 0;

    public int QueuePosition
    {
        get
        {
            return queuePosition;
        }
    }

    protected override void SetSprite()
    {
        if (Ability)
        {
            SetActiveSprite();
        }
        else
        {
            SetBasicSprite();
        }

    }

    /// <summary>
    /// OnMouseDown for a ResearchPane indicates that the user is trying to cancel the given research
    /// </summary>
	protected override void OnMouseDown()
    {
        if (Ability != null)
        {
            LevelAbility clicked = (LevelAbility)Ability;

            clicked.Building.CancelResearch(queuePosition, clicked);
            UIController.GetInstance().Redraw();
            UIController.GetInstance().RedrawAbilities();
        }
    }
}
