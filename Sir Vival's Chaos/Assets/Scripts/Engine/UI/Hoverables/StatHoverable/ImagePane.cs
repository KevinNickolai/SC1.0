using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePane : Hoverable {

    public enum PaneType { DamageType, ArmorType, Attribute }

    [SerializeField]
    private PaneType pt;

    protected override void OnMouseEnter()
    {
        //Display tooltip
        //UIController.GetInstance().DisplayTooltip("Hovering over: " + gameObject.name);

        switch (pt)
        {
            case PaneType.DamageType:
                UIController.GetInstance().DisplayDamageTypeTooltip();
                break;

            case PaneType.ArmorType:
                UIController.GetInstance().DisplayArmorTypeTooltip();
                break;

            case PaneType.Attribute:
                //UIController.GetInstance().DisplayAttributeTooltip();
                throw new System.NotImplementedException("Attributes not displayable currently");                
                //break;
        }
    }

}
