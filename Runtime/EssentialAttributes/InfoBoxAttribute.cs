using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    public enum EInfoMessageType {
        NONE,
        INFO,
        WARNING,
        ERROR
    }
    
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class InfoBoxAttribute : PropertyAttribute {
        public readonly string text;
        public readonly EInfoMessageType messageType;

        public InfoBoxAttribute(string text, EInfoMessageType messageType = EInfoMessageType.INFO) {
            this.text = text;
            this.messageType = messageType;
        }
    }
}