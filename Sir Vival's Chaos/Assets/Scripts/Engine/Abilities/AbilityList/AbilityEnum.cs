using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IEnumerator AbilityEnum class used for the IEnumerable AbilityList class
/// 
/// Basis of class found at:
/// https://msdn.microsoft.com/en-us/library/system.collections.ienumerable.getenumerator(v=vs.110).aspx
/// </summary>
public class AbilityEnum : IEnumerator
{

    public Ability[] _abilities;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public AbilityEnum(Ability[] list)
    {
        _abilities = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _abilities.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Ability Current
    {
        get
        {
            try
            {
                return _abilities[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

}
