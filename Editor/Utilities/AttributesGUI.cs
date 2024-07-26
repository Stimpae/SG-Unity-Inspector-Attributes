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
        
        public static void DrawerPropertyField(Rect rect, SerializedProperty property, bool includeChildren = true, bool drawContainer = false) {
            DrawDrawerPropertyField(rect, property, includeChildren, drawContainer);
        }
        
        private static void DrawPropertyField(SerializedProperty property, bool includeChildren, bool drawContainer) {
            if (!AttributeUtility.IsVisible(property)) return;
            ValidationUtility.ValidateProperty(property);
            
            if(drawContainer) EditorGUILayout.BeginVertical(AttributeEditorStyles.ContainerChildStyle(new RectOffset(0, 0, 0, 0), new RectOffset(0,0, 3, 0)));
            using (new EditorGUI.DisabledScope(!AttributeUtility.IsEnabled(property))) {
                EditorGUILayout.PropertyField(property, AttributeUtility.GetLabel(property), includeChildren);
            }
            if(drawContainer) EditorGUILayout.EndVertical();
        }
        
        private static void DrawDrawerPropertyField(Rect rect, SerializedProperty property, bool includeChildren, bool drawContainer) {
            if (!AttributeUtility.IsVisible(property)) return;
            
            // TODO - if our validation check fails we need to draw a warning box at the top of the inspector
            // TODO - we also need to change how the property field is drawn to show the error?
            
            using (new EditorGUI.DisabledScope(!AttributeUtility.IsEnabled(property))) {
                EditorGUI.PropertyField(rect, property, AttributeUtility.GetLabel(property), includeChildren);
            }
        }
        
        public static void DrawHelpBox(string message, MessageType messageType, bool drawValidationErrors = false) {
            EditorGUILayout.HelpBox(message, messageType);
            if(drawValidationErrors) DrawValidationErrors();
        }
        
        public static void DrawValidationErrors() {
            // Need to 
        }
    }
}
