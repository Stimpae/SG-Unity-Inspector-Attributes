using System;
using UnityEngine;

namespace SG.SG_Inspector_Attributes.Runtime.GroupAttributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FoldoutGroupAttribute : PropertyAttribute {
        public string groupName;
        public FoldoutGroupAttribute(string groupName) {
            this.groupName = groupName;
        }
    }
}