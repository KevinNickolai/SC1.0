using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : IUpgradable {

    protected string name;

    private MageUpgrade mageUpgr;
    private RangeUpgrade rangeUpgr;
    private MeleeUpgrade meleeUpgr;
    private DefenseUpgrade armorUpgr;
    private AuxUpgrade[] auxUpgrs;

    public MeleeUpgrade Melee
    {
        get
        {
            return meleeUpgr;
        }
    }

    public RangeUpgrade Range
    {
        get
        {
            return rangeUpgr;
        }
    }

    public MageUpgrade Mage
    {
        get
        {
            return mageUpgr;
        }
    }

    public AuxUpgrade[] Auxiliary
    {
        get
        {
            return auxUpgrs;
        }
    }

    public DefenseUpgrade Armor
    {
        get
        {
            return armorUpgr;
        }
    }

    void Start()
    {
        mageUpgr = new MageUpgrade();
        rangeUpgr = new RangeUpgrade();
        meleeUpgr = new MeleeUpgrade();
        auxUpgrs = new AuxUpgrade[10];
        armorUpgr = new DefenseUpgrade();
    } 

    public Race()
    {

    }
}