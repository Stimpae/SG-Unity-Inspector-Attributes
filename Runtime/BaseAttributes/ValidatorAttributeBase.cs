using System;
using System.Diagnostics;
using UnityEditor;

namespace TTG.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public abstract class ValidateAttributeBase : Attribute {
    }
}