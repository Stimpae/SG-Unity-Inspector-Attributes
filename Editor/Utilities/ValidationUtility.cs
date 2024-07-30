using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TTG.Attributes {
    public static class ValidationUtility {
        private static Dictionary<string, SerializedProperty> _failedValidations = new Dictionary<string, SerializedProperty>();

        public static void AddFailedValidation(SerializedProperty property) {
            _failedValidations.TryAdd(property.name + "-" + property.serializedObject.targetObject.GetInstanceID(), property);
        }
 
        public static void RemoveFailedValidation(SerializedProperty property) {
            _failedValidations.Remove(property.name + "-" + property.serializedObject.targetObject.GetInstanceID());
        }

        public static void ClearFailedValidations() {
            _failedValidations.Clear();
        }

        public static Dictionary<string, SerializedProperty> GetFailedValidations() {
            return _failedValidations;
        }

        public static SerializedProperty GetFailedValidation(string key) {
            _failedValidations.TryGetValue(key, out var property);
            return property;
        }
        
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
                var key = property.serializedObject.targetObject.GetInstanceID().ToString();
                if (property.objectReferenceValue == null) {
                    var errorMessage = property.name + " is required";
                    if (!string.IsNullOrEmpty(requiredAttribute.ErrorMessage)) {
                        errorMessage = requiredAttribute.ErrorMessage;
                    }

                    AttributesGUI.DrawHelpBox(errorMessage, MessageType.Error);
                    if (!requiredAttribute.RegisterValidation) return;
                    AddFailedValidation(property);
                }
                else {
                    RemoveFailedValidation(property);
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