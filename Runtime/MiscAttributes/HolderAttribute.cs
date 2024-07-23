﻿using System;
using System.Diagnostics;
using UnityEngine;

namespace TTG.Attributes {
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class HolderAttribute : PropertyAttribute {
        
    }
}