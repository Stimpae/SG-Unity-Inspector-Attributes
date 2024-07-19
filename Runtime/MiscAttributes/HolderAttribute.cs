using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.TTG_Editor_Attributes.Runtime.MiscAttributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class HolderAttribute : PropertyAttribute {
        
    }
}