using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TTG.Attributes {
    public static class AttributesGUI 
    {
        public static void PropertyField(SerializedProperty property, bool includeChildren = true) {
            
        }
        
        private static void DrawProperty(SerializedProperty property, GUIContent label,  bool includeChildren) {
            EditorGUILayout.PropertyField(property, label, includeChildren);
        }
        
        private static void HandlePropertyFieldWithAttributes(SerializedProperty property, GUIContent label, bool includeChildren) {
            var attributes = AttributeUtility.GetAttributes<Attribute>(property);
            foreach (var attribute in attributes) {
                if (attribute is LabelAttribute labelAttribute) {
                    if (!string.IsNullOrEmpty(labelAttribute.label)) {
                        label.text = labelAttribute.label;
                    }
                    if (labelAttribute.bold) {
                        var previousFontStyle = EditorStyles.label.fontStyle;
                        EditorStyles.label.fontStyle = FontStyle.Bold;
                        DrawProperty(property, label, includeChildren);
                        EditorStyles.label.fontStyle = previousFontStyle;
                    }
                    else {
                        DrawProperty(property, label, includeChildren);
                    }
                }
                else if (attribute is ReadOnlyAttribute) {
                    GUI.enabled = false;
                    DrawProperty(property, label, includeChildren);
                    GUI.enabled = true;
                }
                else {
                    DrawProperty(property, label, includeChildren);
                }
            }
        }
    }
}
