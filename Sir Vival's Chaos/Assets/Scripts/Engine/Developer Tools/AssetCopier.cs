using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class AssetCopier {

    public static ScriptableObject DeepCopy(ScriptableObject so)
    {

        ScriptableObject test = Object.Instantiate(so);
        AssetDatabase.CreateAsset(test, "Assets/NewAbilityListTest.asset");

        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(test));

        return AssetDatabase.LoadAssetAtPath<AbilityList>("Assets/NewAbilityListTest.asset");
    }

}
