using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class ButtonFieldAttribute : PropertyAttribute {
        public readonly string functionName;
        public readonly string buttonLabel;
        public readonly float buttonHeight;
        
        public ButtonFieldAttribute(string functionName, string buttonLabel, float buttonHeight = 25f) {
            this.buttonLabel = buttonLabel;
            this.buttonHeight = buttonHeight;
            this.functionName = functionName;
        }
        
        
    }
}