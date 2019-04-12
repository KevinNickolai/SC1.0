using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable {

    MeleeUpgrade Melee { get; }
    GateUpgrade Gate { get; }
    MageUpgrade Mage { get; }
    DefenseUpgrade Armor { get; }
    FortUpgrade Fort { get; }

    AuxUpgrade[] Auxiliary { get; }
}
