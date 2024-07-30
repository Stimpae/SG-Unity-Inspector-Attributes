using System;
using System.Diagnostics;
using UnityEditor;

namespace TTG.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ValidateAttributeBase : Attribute {
        public string ErrorMessage { get; protected set; }
    }
}