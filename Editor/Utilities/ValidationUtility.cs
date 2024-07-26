using System;
using System.Collections.Generic;
using UnityEditor;

namespace TTG.Attributes {
    public static class ValidationUtility {
        private static Dictionary<SerializedObject, SerializedProperty> _propertiesByObject = new Dictionary<SerializedObject, SerializedProperty>();
        
        public static void ValidateProperty(SerializedProperty property) {
            var attribute = AttributeUtility.GetAttribute<ValidateAttributeBase>(property);
            switch (attribute) {
                case null:
                    return;
                case RequiredAttribute:
                    RequiredPropertyValidator(property);
                    break;
                case ValidationAttribute:
                    ValidationPropertyValidator(property);
                    break;
            }
        }

        private static void RequiredPropertyValidator(SerializedProperty property) {
            var requiredAttribute = AttributeUtility.GetAttribute<RequiredAttribute>(property);
            if (property.propertyType == SerializedPropertyType.ObjectReference) {
                if (property.objectReferenceValue != null) {
                    var errorMessage = property.name + " is required";
                    if (!string.IsNullOrEmpty(requiredAttribute.ErrorMessage)) {
                        errorMessage = requiredAttribute.ErrorMessage;
                    }
                    AttributesGUI.DrawHelpBox(errorMessage, MessageType.Error);
                    
                    if (!requiredAttribute.DrawValidationBox) return;
                    if (!_propertiesByObject.ContainsKey(property.serializedObject)) _propertiesByObject.Add(property.serializedObject, property);
                }
                else {
                    if (_propertiesByObject.ContainsKey(property.serializedObject)) {
                        _propertiesByObject.Remove(property.serializedObject);
                    }
                }
            }
            else {
                var warning = requiredAttribute.GetType().Name + " works only on reference types";
                AttributesGUI.DrawHelpBox(warning, MessageType.Warning);
            }
        }

        private static void ValidationPropertyValidator(SerializedProperty property) {
            
            
        }
    }
}