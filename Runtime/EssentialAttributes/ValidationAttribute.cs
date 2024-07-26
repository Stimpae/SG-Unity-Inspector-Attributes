using System;
using UnityEditor;

namespace TTG.Attributes{
    public class ValidationAttribute : ValidateAttributeBase{
        public string ValidationCallback { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool DrawValidationBox { get; private set; }
        
        public ValidationAttribute(string validationCallback, string errorMessage = null, bool drawValidationBox = false) {
            ValidationCallback = validationCallback;
            ErrorMessage = errorMessage;
            DrawValidationBox = drawValidationBox;
        }
    }
}