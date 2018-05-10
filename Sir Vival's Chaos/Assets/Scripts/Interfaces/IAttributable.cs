using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttributable : ILevelable {

	int Strength { get; set; }
    int Agility { get; set; }
    int Intelligence { get; set; }

}
