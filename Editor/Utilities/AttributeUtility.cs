using System;
using System.Linq;
using UnityEditor;

namespace TTG.Attributes {
    public static class AttributeUtility {
        public static T[] GetAttributes<T>(SerializedProperty property) where T : class {
            var fieldInfo = ReflectionUtility.GetField(GetTargetObject(property), property.name);
            return fieldInfo == null ? new T[] { } : (T[])fieldInfo.GetCustomAttributes(typeof(T), true);
        }
        
        public static T GetAttribute<T>(SerializedProperty property) where T : class {
            return GetAttributes<T>(property)?.FirstOrDefault();
        }
        
        public static object GetTargetObject(SerializedProperty property) {
            var path = property.propertyPath.Replace(".Array.data[", "[");
            return path.Split('.').SkipLast(1).Aggregate<string, object>(property.serializedObject.targetObject, (current, element) => 
                element.Contains("[") ? ReflectionUtility.GetValue(current, element[..element.IndexOf("[", StringComparison.Ordinal)], int.Parse(element.Split('[', ']')[1])) : ReflectionUtility.GetValue(current, element));
        }
        
        // label
        
        // is visible 
        
        // is enabled?
        
        // is validated?
    }
}