using System;
using System.Diagnostics;
using UnityEditor;

namespace TTG.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Field)]
    [Conditional("UNITY_EDITOR")]
    public class ValidateAttributeBase : Attribute {
        public string ErrorMessage { get; protected set; }
    }
}