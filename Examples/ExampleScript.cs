using System;
using SG.SG_Inspector_Attributes.Runtime.EssentialAttributes;
using SG.SG_Inspector_Attributes.Runtime.MiscAttributes;
using TTG.TTG_Editor_Attributes.Runtime.ButtonAttributes;
using TTG.TTG_Editor_Attributes.Runtime.GroupAttributes;
using TTG.TTG_Editor_Attributes.Runtime.MiscAttributes;
using UnityEngine;

namespace TTG_Editor_Attributes.Examples {
    
    [Serializable]
    public struct DecoratorHolder { }
    
    public class ExampleScript : MonoBehaviour {
        [InfoBox("Example information box, this is some information about this example script. we are using this to show off how things are done", InfoMessageType.WARNING)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        public float exampleFloat;
        public string exampleString;
        public bool exampleBool;
        
        [Splitter(1, 20)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        [Holder] public DecoratorHolder decoratorHolder;
        
        
        [ButtonField(nameof(ExampleMethod), "Example Button", 20)]
        [Holder] public DecoratorHolder decoratorHolder2;
        
        // Groups and Buttons will always be displayed at the bottom of the inspector
        
        [FoldoutGroup("Example Foldout Group")]
        public int exampleInt;
        [FoldoutGroup("Example Foldout Group")]
        public float exampleFloat1;
        [FoldoutGroup("Example Foldout Group 2")]
        public string exampleString2;
        [FoldoutGroup("Example Foldout Group 2")]
        public bool exampleBool3;
        
        [Button("Example Button")]
        public void ExampleMethod() {
            Debug.Log("Example Method Called");
        }
    }
}
