using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building {

    public override void SetProperties(Race race, Player p)
    {
        base.SetProperties(race, p);

        SetStats(race.TowerStats);
    }

}
