using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TTG.Attributes {
    public static class AttributesGUI {
        public static void PropertyField(SerializedProperty property, bool includeChildren = true, bool drawContainer = false) {
            DrawPropertyField(property, includeChildren, drawContainer);
        }
        
        private static void DrawPropertyField(SerializedProperty property, bool includeChildren, bool drawContainer) {
            if (!AttributeUtility.IsVisible(property)) return;
            
            // TODO - if our validation check fails we need to draw a warning box at the top of the inspector
            // TODO - we also need to change how the property field is drawn to show the error?
            
            if(drawContainer) EditorGUILayout.BeginVertical(AttributeEditorStyles.ContainerChildStyle(new RectOffset(0, 0, 0, 0), new RectOffset(0,0, 3, 0)));
            using (new EditorGUI.DisabledScope(!AttributeUtility.IsEnabled(property))) {
                EditorGUILayout.PropertyField(property, AttributeUtility.GetLabel(property), includeChildren);
            }
            if(drawContainer) EditorGUILayout.EndVertical();
        }
    }
}
