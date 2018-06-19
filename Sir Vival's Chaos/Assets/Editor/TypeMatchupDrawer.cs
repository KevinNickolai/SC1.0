using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom Property Drawer for the Damage & Armor matchup ScriptableObject
/// </summary>
[CustomPropertyDrawer(typeof(TypeMatchupTable))]
public class TypeMatchupDrawer : PropertyDrawer {

    Vector2 scrollViewPos = Vector2.zero;

    const float LABEL_WIDTH = 115.0f;
    const float ELEM_SPACING = 50.0f;
    const float ROW_HEIGHT = 25.0f;

    bool showMatchups = true;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Debug.Log("Width : " + position.width.ToString() + "\tHeight : " + position.height.ToString() + "\tX : " + position.x.ToString() + "\tY : " + position.y.ToString());
        //Debug.Log(position.size);

        //Start the property
        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.PropertyField(position, property, GUIContent.none);

        if(property.objectReferenceValue != null)
        {
            EditorGUI.BeginChangeCheck();

            SerializedObject soMatchup = new SerializedObject(property.objectReferenceValue);

            /** 
             * get the properties for damage & armor types
             */
            SerializedProperty damageTypes = soMatchup.FindProperty("damageTypes");
            SerializedProperty armorTypes = soMatchup.FindProperty("armorTypes");
            SerializedProperty matchups = soMatchup.FindProperty("matchups");

            //Set the array size for the matchups list to the damage types array size, setting up the 2d array
            matchups.arraySize = damageTypes.arraySize;

            #region X-axis labels of table

            position.y += ROW_HEIGHT;
            float resetY = position.y;

            Rect xAxisPos = position;

            //Setting up the ArmorType labels above columns for the matchup 2d array
            for (int i = 0; i < armorTypes.arraySize; ++i)
            {
                //offsetting the first column of the layout, to allow ArmorType labels to be directly over their corresponding column
                xAxisPos.x += LABEL_WIDTH + ELEM_SPACING;

                //getting the object reference at a position in the damage types list
                Object obj = armorTypes.GetArrayElementAtIndex(i).objectReferenceValue;

                //if the object is null, we need to indicated that in labeling as null has no type
                if (!obj)
                {
                    EditorGUI.LabelField(xAxisPos, "Null ArmorType");
                }
                else
                {
                    //display the type
                    EditorGUI.LabelField(xAxisPos, obj.GetType().ToString());
                }
                
            }

            #endregion

            #region Y-axis labels of table

            xAxisPos.x = 0;

            for(int i = 0; i < damageTypes.arraySize; ++i)
            {
                xAxisPos.y += ROW_HEIGHT;

                /**
                 * getting the object reference at a position in the damage types list
                 */
                Object obj = damageTypes.GetArrayElementAtIndex(i).objectReferenceValue;

                //if the object is null, we need to indicated that in labeling as null has no type
                if (!obj)
                {
                    EditorGUI.LabelField(xAxisPos, "Null DamageType");
                }
                else
                {
                    //display the type
                    EditorGUI.LabelField(xAxisPos, obj.GetType().ToString());
                }
            }
            #endregion

            xAxisPos.y = resetY;

            Rect totalArea = new Rect(xAxisPos.x,xAxisPos.y,((LABEL_WIDTH + ELEM_SPACING) * (armorTypes.arraySize))/xAxisPos.width, xAxisPos.height);

            //Debug.Log(totalArea.width);
            //totalArea.x = xAxisPos.x;
            //totalArea.y = xAxisPos.y;
            //totalArea.width = ;
            //totalArea.height = (ROW_HEIGHT) * (damageTypes.arraySize);

            totalArea.x += LABEL_WIDTH;

            Rect view = new Rect(position.x + (LABEL_WIDTH), xAxisPos.y, ((LABEL_WIDTH + ELEM_SPACING) * armorTypes.arraySize),  ROW_HEIGHT * (damageTypes.arraySize + 2));
            scrollViewPos = GUI.BeginScrollView(view, scrollViewPos, totalArea, true, false);


            for (int i = 0; i < damageTypes.arraySize; ++i)
            {
                xAxisPos.x = 0;
                xAxisPos.y += ROW_HEIGHT;
                xAxisPos.xMax = LABEL_WIDTH;

                /**
                 * Get the list wrapper and its list to set types
                 */
                SerializedProperty listWrapper = matchups.GetArrayElementAtIndex(i);
                SerializedProperty listWrapperList = listWrapper.FindPropertyRelative("list");

                listWrapperList.arraySize = armorTypes.arraySize;

                //listing each element of the damage types
                for (int j = 0; j < armorTypes.arraySize; ++j)
                {
                    xAxisPos.x += LABEL_WIDTH + ELEM_SPACING;

                    SerializedProperty intProperty = listWrapperList.GetArrayElementAtIndex(j);
                    if (intProperty.intValue == 0)
                    {
                        intProperty.intValue = 100;
                    }
                    intProperty.intValue = EditorGUI.IntSlider(xAxisPos, intProperty.intValue, 1, 200);
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                soMatchup.ApplyModifiedProperties();
            }

            GUI.EndScrollView();

        }

        EditorGUI.EndProperty();


    }
}
