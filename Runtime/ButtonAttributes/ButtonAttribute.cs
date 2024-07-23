using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class ButtonAttribute : PropertyAttribute {
        public readonly string buttonText;
        
        public ButtonAttribute(string buttonText = null) {
            this.buttonText = buttonText;
        }
    }
}
