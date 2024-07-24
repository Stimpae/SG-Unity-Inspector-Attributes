using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TTG.Attributes;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Object = System.Object;

namespace TTG.Attributes {
    // ReSharper disable once InconsistentNaming
    [CustomEditor(typeof(Object), true)]
    public class TTGEditor : UnityEditor.Editor {
        private List<SerializedProperty> m_serializedProperties = new List<SerializedProperty>();
        private IEnumerable<IGrouping<string, SerializedProperty>> m_boxGroupedProperties;
        public IEnumerable<IGrouping<string, SerializedProperty>> m_foldoutGroupedProperties;
        private IEnumerable<IGrouping<string, SerializedProperty>> m_tabGroupedProperties;
        
        private IEnumerable<SerializedProperty> m_noneGroupedProperties;
        private IEnumerable<MethodInfo> m_buttonMethods;

        public Dictionary<string, EditorBool> m_foldoutStates = new Dictionary<string, EditorBool>();
        
        private void OnEnable() {
            m_serializedProperties.Clear();
            m_serializedProperties = PropertyUtility.GetSerializedProperties(serializedObject);
       
            m_foldoutGroupedProperties = m_serializedProperties
                .Where(p => AttributeUtility.GetAttribute<FoldoutGroupAttribute>(p) != null)
                .GroupBy(p => AttributeUtility.GetAttribute<FoldoutGroupAttribute>(p).GroupName);
            
            m_boxGroupedProperties = m_serializedProperties
                .Where(p => AttributeUtility.GetAttribute<BoxGroupAttribute>(p) != null)
                .GroupBy(p => AttributeUtility.GetAttribute<BoxGroupAttribute>(p).GroupName);

            m_noneGroupedProperties = m_serializedProperties
                .Where(p => AttributeUtility.GetAttribute<FoldoutGroupAttribute>(p) == null &&
                            AttributeUtility.GetAttribute<BoxGroupAttribute>(p) == null);

            m_buttonMethods = ReflectionUtility.GetMethods(target, methodInfo
                => methodInfo.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0);
        }
        
        public override void OnInspectorGUI() {
            serializedObject.Update();
            DrawProperties();
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawProperties() {
            // todo Draw validated property errors if there are any
            
            foreach (var property in m_noneGroupedProperties) {
                if (property.name == "m_Script") continue;
                AttributesGUI.PropertyField(property,true);
            }
            GUILayout.Space(10);
            
            DrawBoxGroups();
            DrawFoldoutGroups();
            // todo - Draw tab groups
            
            GUILayout.Space(10);
            
            DrawButtons();
        }
        
        private void DrawButtons() {
            foreach (var method in m_buttonMethods) {
                if (!GUILayout.Button(ObjectNames.NicifyVariableName(method.Name))) continue;
                method.Invoke(target, method.GetParameters().Select(p => p.DefaultValue).ToArray());
                EditorUtility.SetDirty(target);
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
        }
        
        private void DrawBoxGroups() {
            foreach (var properties in m_boxGroupedProperties) {
                var groupName = properties.Key;
                
                EditorGUILayout.BeginVertical(AttributeEditorStyles.ContainerStyle(new RectOffset(5, 7, 0, 0), true));
                Rect verticalGroup = EditorGUILayout.BeginVertical();
                var serializedProperties = properties.ToList();
            
                var boxGroupAttribute = AttributeUtility.GetAttribute<BoxGroupAttribute>(serializedProperties.First());
                var color = AttributeEditorStyles.GetColor(boxGroupAttribute.ColorIndex);
                AttributeEditorStyles.DrawIdentifierLine(verticalGroup, color);
            
                EditorGUILayout.LabelField(groupName, AttributeEditorStyles.HeaderStyle(true, 12, new RectOffset(-2, 0, 0, 0)));
                
                foreach (var property in serializedProperties) {
                    AttributesGUI.PropertyField(property,true, true);
                    if (serializedProperties.Last() == property) GUILayout.Space(5);
                }
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
            }
        }
        
        private void DrawFoldoutGroups() {
            foreach (var properties in m_foldoutGroupedProperties) {
                var groupName = properties.Key;
                
                if (!m_foldoutStates.ContainsKey(groupName)) {
                    m_foldoutStates[groupName] = new EditorBool($"{target.GetInstanceID()}.{properties.Key}", false);
                }

                EditorGUILayout.BeginVertical(AttributeEditorStyles.ContainerStyle(new RectOffset(15, 7, 0, 0)));
                Rect verticalGroup = EditorGUILayout.BeginVertical();

                var serializedProperties = properties.ToList();
            
                var foldoutGroupAttribute = AttributeUtility.GetAttribute<FoldoutGroupAttribute>(serializedProperties.First());
                var color = AttributeEditorStyles.GetColor(foldoutGroupAttribute.ColorIndex);
                AttributeEditorStyles.DrawIdentifierLine(verticalGroup, color);
            
                m_foldoutStates[groupName].Value = EditorGUILayout.Foldout(m_foldoutStates[groupName].Value, groupName, AttributeEditorStyles.FoldoutStyle(true, 12));
                if (m_foldoutStates[groupName].Value) {
                    foreach (var property in serializedProperties) {
                        AttributesGUI.PropertyField(property,true, true);
                        if (serializedProperties.Last() == property) GUILayout.Space(5);
                    }
                }
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
            }
        }
    }
}