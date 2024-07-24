using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Field)]
    [Conditional("UNITY_EDITOR")]
    public class StructAttribute : PropertyAttribute {

    }
}