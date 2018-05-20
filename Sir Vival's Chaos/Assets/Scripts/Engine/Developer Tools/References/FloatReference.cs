using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class describing an FloatReference type that can allow for a variable or constant reference to an float in memory
/// </summary>
[CreateAssetMenu(fileName = "NewFloatReference", menuName = "Values/References/FloatReference", order = 2)]
public class FloatReference : Reference<float>
{
    /// <summary>
    /// The Variable aspect of the reference
    /// </summary>
    protected FloatVariable Variable;

    /// <summary>
    /// The value of the IntReference
    /// </summary>
    public override float Value
    {
        get
        {
            return (UseConstant ? ConstantValue : Variable.Value);
        }
    }
}
