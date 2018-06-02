using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class that describes a reference type,
/// Where a constant variable type (i.e. int, float)
/// and a Variable variable type (one made by the developer, such as an IntVariable, FloatVariable,
/// to have a specific value in memory that can be referenced by many different objects)
/// can be created to allow for use of either a constant or variable in Unity's inspector
/// </summary>
[System.Serializable]
public class Reference<T,Tvar> : ScriptableObject where Tvar : Variable<T> {

    /// <summary>
    /// flag indicator to use the constant value or variable value of the reference
    /// </summary>
    [SerializeField]
    protected bool UseConstant = true;

    /// <summary>
    /// The constant value of the reference
    /// </summary>
    [SerializeField]
    protected T ConstantValue;

    /// <summary>
    /// The variable value of the reference
    /// </summary>
    [SerializeField]
    protected Tvar Variable;

    /// <summary>
    /// The value the reference contains
    /// </summary>
    public T Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.Value;
        }
    }

    /// <summary>
    /// Set the constant value of the reference
    /// </summary>
    /// <param name="constVal">the constant value to set for the reference</param>
    public void SetConstant(T constVal)
    {
        ConstantValue = constVal;
    }
}
