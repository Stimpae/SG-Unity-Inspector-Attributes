﻿using UnityEngine;

namespace TTG.Attributes.Examples {
    [CreateAssetMenu(fileName = "ExampleScriptable", menuName = "TTG/Attributes/Examples/ExampleScriptable")]
    public class ExampleScriptable : ScriptableObject {
        [ReadOnly] public int readOnlyInt = 141234;

        [Label("Example Label Of Fury", true)] public string exampleLabelString;
        [Label()] public string emptyLabelString;
        
        [SerializeField] private  float exampleFloat;
        public string exampleString;
        public bool exampleBool;
        
        [Title("Example Title", "Example Description", showLine: true, bold: true)]
        [Holder] public DecoratorHolder decoratorHolder1;
        
        [InfoBox("Example information box, this is some information about this example script. we are using this to show off how things are done", EInfoMessageType.WARNING)]
        [Holder] public DecoratorHolder decoratorHolder2;
        
        [ButtonField("ExampleMethod", "Example Button Field", 30)]
        [Holder] public DecoratorHolder decoratorHolder3;
        
        public void ExampleMethod() {
            Debug.Log("Example Method Called");
        }
        
        //[FoldoutGroup("Example Foldout Group",5)] public int exampleIntFoldout;
        //[FoldoutGroup("Example Foldout Group")] public float exampleFloat1Foldout;
        
        //[FoldoutGroup("Example Foldout Group 1",5)] public int exampleIntFoldout1; 
        //[FoldoutGroup("Example Foldout Group 1")] public float exampleFloat1Foldout1;
        
        //[FoldoutGroup("Example Foldout Group 2",5)] public int exampleIntFoldout2;
        //[FoldoutGroup("Example Foldout Group 2")] public float exampleFloat1Foldout2;
    }
}