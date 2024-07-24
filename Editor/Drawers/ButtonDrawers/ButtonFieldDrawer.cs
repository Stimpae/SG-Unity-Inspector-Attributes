using UnityEditor;
using UnityEngine;

namespace TTG.Attributes {
    [CustomPropertyDrawer(typeof(ButtonFieldAttribute))]
    public class ButtonFieldDrawer : PropertyDrawer{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            ButtonFieldAttribute buttonFieldAttribute = (ButtonFieldAttribute) attribute;
            
            // set the button height 
            position.height = buttonFieldAttribute.buttonHeight;
            if (GUI.Button(position, buttonFieldAttribute.buttonLabel)) {
                property.serializedObject.targetObject.GetType().GetMethod(buttonFieldAttribute.functionName)?.Invoke(property.serializedObject.targetObject, null);
            }
            
            if (property.propertyType == SerializedPropertyType.Generic) return;
            position.y += buttonFieldAttribute.buttonHeight + 5;
            EditorGUI.PropertyField(position, property, label);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            ButtonFieldAttribute buttonFieldAttribute = (ButtonFieldAttribute) attribute;
            
            float height = buttonFieldAttribute.buttonHeight;
            if (property.propertyType == SerializedPropertyType.Generic) return height;
            return height + 6.5f + EditorGUIUtility.singleLineHeight;
        }
    }
}