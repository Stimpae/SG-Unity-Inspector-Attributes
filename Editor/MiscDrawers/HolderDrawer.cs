using TTG.TTG_Editor_Attributes.Runtime.MiscAttributes;
using UnityEditor;
using UnityEngine;

namespace TTG.TTG_Editor_Attributes.Editor.MiscAttributes {
    [CustomPropertyDrawer(typeof(HolderAttribute))]
    public class HolderDrawer : PropertyDrawer{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property, GUIContent.none);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return 0;
        }
    }
}