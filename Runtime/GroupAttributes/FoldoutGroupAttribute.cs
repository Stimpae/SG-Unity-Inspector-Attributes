using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.TTG_Editor_Attributes.Runtime.GroupAttributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class FoldoutGroupAttribute : Attribute {
        public string GroupName { get; private set; }
        public FoldoutGroupAttribute(string groupName) {
            this.GroupName = groupName;
        }
    }
}