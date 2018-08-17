/*
* Created by Daniel Mak
*/

using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinAttribute))]
public class MinDrawer : PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        MinAttribute min = (MinAttribute)attribute;

        if (property.propertyType == SerializedPropertyType.Float || property.propertyType == SerializedPropertyType.Integer) {
            if (property.floatValue < min.min) property.floatValue = min.min;
            label.text += " (>=" + min.min + ")";

            property.floatValue = EditorGUI.FloatField(position, label, property.floatValue);
        } else {
            Debug.LogError("Min Attribute does not support the type of the variable: " + property.name);
        }
    }
}