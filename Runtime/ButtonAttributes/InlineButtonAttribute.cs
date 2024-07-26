using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Field)]
    [Conditional("UNITY_EDITOR")]
    public class InlineButtonAttribute : PropertyAttribute {
        public string ButtonLabel { get; private set;}
        public string MethodName { get; private set; }

        public InlineButtonAttribute(string buttonLabel, string methodName) {
            ButtonLabel = buttonLabel;
            MethodName = methodName;
        }
        
    }
}