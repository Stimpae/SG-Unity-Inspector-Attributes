using System.Collections.Generic;
using SG.SG_Inspector_Attributes.Runtime.GroupAttributes;
using UnityEditor;
using UnityEngine;

namespace SG.SG_Inspector_Attributes.Editor.GroupAttributes {
    [CustomPropertyDrawer(typeof(FoldoutGroupAttribute))]
    public class FoldoutGroupDrawer : PropertyDrawer
    {
        private static readonly Dictionary<string, bool> foldoutStates = new Dictionary<string, bool>();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var foldoutGroup = (FoldoutGroupAttribute)attribute;
            if (!foldoutStates.ContainsKey(foldoutGroup.groupName))
            {
                foldoutStates[foldoutGroup.groupName] = true;
            }

            foldoutStates[foldoutGroup.groupName] = EditorGUILayout.Foldout(foldoutStates[foldoutGroup.groupName], foldoutGroup.groupName, true);
            if (!foldoutStates[foldoutGroup.groupName]) return;
            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(position, property, true);
            EditorGUI.indentLevel--;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var foldoutGroup = (FoldoutGroupAttribute)attribute;
            if (foldoutStates.ContainsKey(foldoutGroup.groupName) && foldoutStates[foldoutGroup.groupName])
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}