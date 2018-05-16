using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityContainable {

    AbilityList GetNewNexusAbilities(Nexus nexus);

    AbilityList GetNewBarrackAbilities(Barrack barrack);

    AbilityList GetNewTowerAbilities();

}
