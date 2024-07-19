using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SG;
using TTG.TTG_Editor_Attributes.Editor.Utilities;
using TTG.TTG_Editor_Attributes.Runtime.ButtonAttributes;
using TTG.TTG_Editor_Attributes.Runtime.GroupAttributes;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TTG.TTG_Editor_Attributes.Editor {
    // ReSharper disable once InconsistentNaming
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class TTGEditor : UnityEditor.Editor {
        private List<SerializedProperty> m_serializedProperties = new List<SerializedProperty>();
        private IEnumerable<IGrouping<string, SerializedProperty>> m_boxGroupedProperties;
        private IEnumerable<IGrouping<string, SerializedProperty>> m_foldoutGroupedProperties;
        private IEnumerable<IGrouping<string, SerializedProperty>> m_tabGroupedProperties;
        
        private IEnumerable<SerializedProperty> m_noneGroupedProperties;
        private IEnumerable<MethodInfo> m_buttonMethods;

        private Dictionary<string, bool> m_foldoutStates = new Dictionary<string, bool>();

        private void OnEnable() {
            m_serializedProperties.Clear();
            m_serializedProperties = SerializedPropertyUtility.GetSerializedProperties(serializedObject);
       
            m_foldoutGroupedProperties = m_serializedProperties
                .Where(p => SerializedPropertyUtility.GetAttribute<FoldoutGroupAttribute>(p) != null)
                .GroupBy(p => SerializedPropertyUtility.GetAttribute<FoldoutGroupAttribute>(p).GroupName);
            
            m_noneGroupedProperties = m_serializedProperties
                .Where(p => SerializedPropertyUtility.GetAttribute<FoldoutGroupAttribute>(p) == null &&
                            SerializedPropertyUtility.GetAttribute<BoxGroupAttribute>(p) == null);

            m_buttonMethods = SerializedPropertyUtility.GetMethods(target, methodInfo
                => methodInfo.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0);
        }
        
        public override void OnInspectorGUI() {
            serializedObject.Update();
            DrawProperties();
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawProperties() {

            foreach (var property in m_noneGroupedProperties) {
                if (property.name.Equals("m_Script")) {
                    GUI.enabled = false;
                    EditorGUILayout.PropertyField(property);
                    GUI.enabled = true;
                    continue;
                }

                EditorGUILayout.PropertyField(property);
            }

            foreach (var foldoutGroup in m_foldoutGroupedProperties) {
                var groupKey = foldoutGroup.Key;

                if (!m_foldoutStates.ContainsKey(groupKey)) {
                    m_foldoutStates[groupKey] = false;
                }

                m_foldoutStates[groupKey] = EditorGUILayout.Foldout(m_foldoutStates[foldoutGroup.Key], groupKey);
                if (!m_foldoutStates[foldoutGroup.Key]) continue;
                foreach (var property in foldoutGroup) {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            foreach (var method in m_buttonMethods) {
                var buttonAttribute = (ButtonAttribute)method.GetCustomAttribute(typeof(ButtonAttribute));
                var buttonText = string.IsNullOrEmpty(buttonAttribute.buttonText)
                    ? ObjectNames.NicifyVariableName(method.Name)
                    : buttonAttribute.buttonText;

                if (!GUILayout.Button(buttonText)) continue;

                var defaultParams = method.GetParameters().Select(p => p.DefaultValue).ToArray();
                var methodResult = method.Invoke(target, defaultParams) as IEnumerator;

                if (Application.isPlaying) {
                    if (methodResult != null && target is MonoBehaviour behaviour) {
                        behaviour.StartCoroutine(methodResult);
                    }

                    continue;
                }

                EditorUtility.SetDirty(target);
                var stage = PrefabStageUtility.GetCurrentPrefabStage();
                EditorSceneManager.MarkSceneDirty(stage?.scene ?? EditorSceneManager.GetActiveScene());
            }
        }
    }
}