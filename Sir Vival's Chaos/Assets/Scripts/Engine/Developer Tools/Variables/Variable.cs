using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing a general variable value of type T
/// </summary>
/// <typeparam name="T">The type of the Variable to create a field for</typeparam>
[System.Serializable]
public abstract class Variable<T> : ScriptableObject {
    public T Value;
}
