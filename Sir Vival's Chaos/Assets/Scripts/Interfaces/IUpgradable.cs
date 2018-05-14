using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable {

    MeleeUpgrade Melee { get; }
    RangeUpgrade Range { get; }
    MageUpgrade Mage { get; }
    DefenseUpgrade Armor { get; }

    AuxUpgrade[] Auxiliary { get; }
}
