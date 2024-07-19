using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace TTG.TTG_Editor_Attributes.Editor.Utilities {
    public static class SerializedPropertyUtility {

        public static List<SerializedProperty> GetSerializedProperties(SerializedObject target) {
            var properties = new List<SerializedProperty>();
            var iterator = target.GetIterator();
            if (iterator.NextVisible(true)) {
                do {
                    properties.Add(target.FindProperty(iterator.name));
                } while (iterator.NextVisible(false));
            }
            return properties;
        }

        public static T[] GetAttributes<T>(SerializedProperty property) where T : class {
            FieldInfo fieldInfo = GetField(GetTargetObjectWithProperty(property), property.name);
            return fieldInfo == null ? new T[] { } : (T[])fieldInfo.GetCustomAttributes(typeof(T), true);
        }
        
        public static T GetAttribute<T>(SerializedProperty property) where T : class {
            return GetAttributes<T>(property)?.FirstOrDefault();
        }
        
        public static object GetTargetObjectWithProperty(SerializedProperty property) {
            var path = property.propertyPath.Replace(".Array.data[", "[");
            return path.Split('.').SkipLast(1).Aggregate<string, object>(property.serializedObject.targetObject, (current, element) => 
                element.Contains("[") ? GetValue(current, element.Substring(0, element.IndexOf("[", StringComparison.Ordinal)), int.Parse(element.Split('[', ']')[1])) : GetValue(current, element));
        }

        private static object GetValue(object source, string name, int index = -1) {
            if (source == null) return null;
            var field = source.GetType().GetField(name, BindingFlags.Public | BindingFlags.Instance);
            if (field == null) return null;
            var value = field.GetValue(source);
            if (index < 0) return value;
            return (value as IEnumerable)?.Cast<object>().ElementAtOrDefault(index);
        }
        
        public static FieldInfo GetField(object target, string fieldName) {
            return target.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        }
        
        public static MethodInfo GetMethod(object target, string methodName) {
            return target.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        }
        
        public static MethodInfo[] GetMethods(object target, Func<MethodInfo, bool> predicate) {
            return target.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).Where(predicate).ToArray();
        }
        
        
    }
}