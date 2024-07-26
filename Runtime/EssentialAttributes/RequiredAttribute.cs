using UnityEditor;

namespace TTG.Attributes {
    public class RequiredAttribute : ValidateAttributeBase { 
        public string ErrorMessage { get; private set; }
        public bool DrawValidationBox { get; private set; }

        public RequiredAttribute(string errorMessage = null, bool drawValidationBox = false)
        {
            ErrorMessage = errorMessage;
            DrawValidationBox = drawValidationBox;
        }
    }
}