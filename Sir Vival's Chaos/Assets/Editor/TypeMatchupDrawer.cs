using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom Property Drawer for the Damage & Armor matchup ScriptableObject
/// </summary>
[CustomPropertyDrawer(typeof(TypeMatchupTable))]
public class TypeMatchupDrawer : PropertyDrawer {

    const float LABEL_WIDTH = 150.0f;
    const float ELEM_SPACING = 25.0f;
    const float TOTAL_SPACING = LABEL_WIDTH + ELEM_SPACING;
    const float ROW_HEIGHT = 25.0f;

    Vector2 horizontalScrollPos = Vector2.zero;
    Vector2 verticalScrollPos = Vector2.zero;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Start the property
        label = EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PropertyField(position, property, label);

        //increment position after the property field
        position.y += ROW_HEIGHT;

        if (property.objectReferenceValue != null)
        {
            EditorGUI.BeginChangeCheck();

            SerializedObject soMatchup = new SerializedObject(property.objectReferenceValue);

            /** 
             * get the properties for damage & armor types
             */
            SerializedProperty damageTypes = soMatchup.FindProperty("damageTypes");
            SerializedProperty armorTypes = soMatchup.FindProperty("armorTypes");
            SerializedProperty matchups = soMatchup.FindProperty("matchups");

            //the total height of the table, including a label height at the top of the column
            float tableHeightWithLabel = ROW_HEIGHT * (damageTypes.arraySize + 1);

            //the height of the table without the column label
            float tableHeight = ROW_HEIGHT * damageTypes.arraySize;

            //the total width of the table, including a label width to the left of the row
            float tableWidthWithLabel = LABEL_WIDTH + (TOTAL_SPACING * (armorTypes.arraySize + 1));

            //the width of the table without the row label
            float tableWidth = LABEL_WIDTH + (TOTAL_SPACING * armorTypes.arraySize);



            //Set the array size for the matchups list to the damage types array size, setting up the 2d array
            matchups.arraySize = damageTypes.arraySize;

            #region Horizontal Labels and Scrollbar

            /**
             * Retrieve the width of the vertical scrollbar from the GUI's skin to use as an offset for vertical scrollbar positioning
             */
            float minWid, maxWid;
            GUI.skin.GetStyle("verticalScrollbar").CalcMinMaxWidth(GUIContent.none, out minWid, out maxWid);



            /**
             * Create the rectangles for the horizontal scrollbar
             */
            Rect horizScrollPosRect = new Rect(
                LABEL_WIDTH, //< offset the horizontal labels and horizontal scrollbar to allow room on the left side of the GUI for vertical elements
                position.y, //< use the current vertical position for placement of the horizontal scrollbar
                position.width - LABEL_WIDTH - maxWid, //< offset the width negatively by a LABEL_WIDTH space, to position the right end of the horizontal scrollbar and rect on the right end of the GUI due to the current offset of the left side of the rect.
                tableHeightWithLabel + maxWid); //< height of the horizontal scroll pos rect should be equal to the number of rows plus an extra row for the horizontal labels, plus the max width of a scrollbar.


            Rect horizScrollViewRect = new Rect(
                TOTAL_SPACING, //< Line the horizontal view rect contents up with the horizontal scrollbar, and fit all elements within the view rect
                position.y, //< use the current vertical position for placement of the view rect at the appropriate y
                (TOTAL_SPACING * armorTypes.arraySize)-ELEM_SPACING, //<make the width of the horizScrollViewRect the width of all element spacing and sizing for each horizontal element; minus an element spacing for the last element's space
                ROW_HEIGHT); //< make the height of the horizScrollViewRect the height of a single row, since this is the horizontal row for label scrolling

            //EditorGUI.DrawRect(horizScrollPosRect, Color.gray);
            //EditorGUI.DrawRect(horizScrollViewRect, Color.red);



            /**
             * Create the rectangles for the vertical scrollbar
             */
            Rect vertScrollPosRect = new Rect(
                0,
                position.y + ROW_HEIGHT,
                position.width,
                tableHeight
                );


            Rect vertScrollViewRect = new Rect(
                0, //< x position of the vertical scrollbar is the left side of the window showing the scrollbar
                position.y + ROW_HEIGHT, //< vertical view rect using position.y, incremented by an extra row to account for the horizontal elements of the table
                LABEL_WIDTH, //< The width of the vertical scroll view should be 1 label width
                tableHeight //< the height of the vertical scroll view is the height of the table without labels
                );

            //EditorGUI.DrawRect(vertScrollPosRect, Color.cyan);
            //EditorGUI.DrawRect(vertScrollViewRect, Color.red);

            //make the horizontal scroller for the horizontal labels
            horizontalScrollPos = GUI.BeginScrollView(horizScrollPosRect, horizontalScrollPos,horizScrollViewRect);


            #region horizontal labels of table

            //reset on horizontal scroll view rect x for later use in the totalareaviewrect
            float horizXReset = horizScrollViewRect.x;

            //centering the horizontal labels
            horizScrollViewRect.x += (TOTAL_SPACING) / 8;

            //rectangle to distinguish one column's properties from another
            Rect column = new Rect(
    LABEL_WIDTH,
    position.y,
    TOTAL_SPACING,
    tableHeightWithLabel
    );
            //distinguishing colors of the table
            Color lightGray = new Color(.7f, .7f, .7f, 1);
            Color lighterGray = new Color(.85f, .85f, .85f, 1);

            //Setting up the ArmorType labels above columns for the matchup 2d array
            for (int i = 0; i < armorTypes.arraySize; ++i)
            {
                //getting the object reference at a position in the damage types list
                Object obj = armorTypes.GetArrayElementAtIndex(i).objectReferenceValue;

                EditorGUI.DrawRect(column, i % 2 == 0 ? lighterGray : lightGray);

                //if the object is null, we need to indicated that in labeling as null has no type
                if (!obj)
                {
                    EditorGUI.LabelField(horizScrollViewRect, "Null ArmorType");
                }
                else
                {
                    //display the type
                    EditorGUI.LabelField(horizScrollViewRect, obj.GetType().ToString());
                }

                //offsetting the first column of the layout, to allow ArmorType labels to be directly over their corresponding column
                horizScrollViewRect.x += TOTAL_SPACING;

                column.x += TOTAL_SPACING;

            }

            horizScrollViewRect.x = horizXReset;
            #endregion

            GUI.EndScrollView();
            #endregion

            #region Vertical Labels and Scrollbar

            verticalScrollPos = GUI.BeginScrollView(vertScrollPosRect, verticalScrollPos, vertScrollViewRect,false,true);

            #region Y-axis labels of table

            //center the vertical labels
            vertScrollViewRect.x = (LABEL_WIDTH) / 8;
            for (int i = 0; i < damageTypes.arraySize; ++i)
            {

                //getting the object reference at a position in the damage types list                 
                Object obj = damageTypes.GetArrayElementAtIndex(i).objectReferenceValue;

                //if the object is null, we need to indicated that in labeling as null has no type
                if (!obj)
                {
                    EditorGUI.LabelField(vertScrollViewRect, "Null DamageType");
                }
                else
                {
                    //display the type
                    EditorGUI.LabelField(vertScrollViewRect, obj.GetType().ToString());
                }
                vertScrollViewRect.y += ROW_HEIGHT;

            }
            #endregion

            GUI.EndScrollView();

            #endregion

            Rect totalAreaPosRect = new Rect(
                LABEL_WIDTH, 
                position.y + ROW_HEIGHT,
                horizScrollPosRect.width,
                tableHeight
                );

            Rect totalAreaViewRect = new Rect(
                LABEL_WIDTH,
                position.y + ROW_HEIGHT,
                horizScrollViewRect.width,
                vertScrollViewRect.height
                );

            //EditorGUI.DrawRect(totalAreaPosRect, Color.red);
            //EditorGUI.DrawRect(totalAreaViewRect, Color.cyan);
            Rect size = new Rect(0, position.y, TOTAL_SPACING, GUI.skin.GetStyle("horizontalSlider").CalcHeight(GUIContent.none,TOTAL_SPACING));
            size.xMax = LABEL_WIDTH;

            /**
             * Create a scroll view for the main content of the TypeMatchupDrawer body; this scrollview is a composition of the horizontal and vertical scrollviews
             * created above for the horizontal and vertical labels. This composite scroll view won't display its scrollbars, as the horizontal and vertical
             * scrollers above already handle relevant positioning for the composite scrollbar used here.
             */
            GUI.BeginScrollView(totalAreaPosRect, new Vector2(horizontalScrollPos.x, verticalScrollPos.y), totalAreaViewRect,GUIStyle.none, GUIStyle.none);

            for (int i = 0; i < damageTypes.arraySize; ++i)
            {
                //reset the rect from the starting position of the 
                size.x = LABEL_WIDTH;

                size.y += ROW_HEIGHT;

                /**
                 * Get the list wrapper and its list to set types
                 */
                SerializedProperty listWrapper = matchups.GetArrayElementAtIndex(i);
                SerializedProperty listWrapperList = listWrapper.FindPropertyRelative("list");

                listWrapperList.arraySize = armorTypes.arraySize;

                //listing each element of the damage types
                for (int j = 0; j < armorTypes.arraySize; ++j)
                {

                    SerializedProperty intProperty = listWrapperList.GetArrayElementAtIndex(j);
                    if (intProperty.intValue == 0)
                    {
                        intProperty.intValue = 100;
                    }
                    //EditorGUI.DrawRect(size, j % 2 == 0 ? Color.white : Color.gray);
                    intProperty.intValue = EditorGUI.IntSlider(size, intProperty.intValue, 1, 200);

                    size.x += TOTAL_SPACING;

                }
            }
            GUI.EndScrollView();

            if (EditorGUI.EndChangeCheck())
            {
                soMatchup.ApplyModifiedProperties();
            }

        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
