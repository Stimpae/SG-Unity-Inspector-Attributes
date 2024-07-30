using UnityEditor;

namespace TTG.Attributes {
    public class RequiredAttribute : ValidateAttributeBase {
        public bool RegisterValidation { get; private set; }
        public RequiredAttribute(string errorMessage = null, bool registerValidation = false) {
            ErrorMessage = errorMessage;
            RegisterValidation = registerValidation;
        }
    }
}