using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResearchPane : AbilityPane {

    [SerializeField]
    private int queuePosition = 0;

    public int QueuePosition
    {
        get
        {
            return queuePosition;
        }
    }

    /// <summary>
    /// OnMouseDown for a ResearchPane indicates that the user is trying to cancel the given research
    /// </summary>
	protected override void OnMouseDown()
    {
        if (Ability != null)
        {
            ((LevelAbility)Ability).Building.CancelResearch(queuePosition);
            UIController.GetInstance().Redraw();
        }
    }
}
