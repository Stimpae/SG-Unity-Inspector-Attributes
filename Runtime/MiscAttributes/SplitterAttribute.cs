using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.TTG_Editor_Attributes.Runtime.MiscAttributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class SplitterAttribute : PropertyAttribute {
        public readonly int thickness;
        public readonly int padding;
        public SplitterAttribute(int thickness = 1, int padding = 0) {
            this.thickness = thickness;
            this.padding = padding;
        }
    }
}