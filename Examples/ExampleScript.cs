using SG.SG_Inspector_Attributes.Runtime.DecoratorAttributes;
using SG.SG_Inspector_Attributes.Runtime.EssentialAttributes;
using SG.SG_Inspector_Attributes.Runtime.GroupAttributes;
using SG.SG_Inspector_Attributes.Runtime.MiscAttributes;
using UnityEngine;

namespace SG_Inspector_Attributes.Examples {
    public class ExampleScript : MonoBehaviour {
        
        [InfoBox("Example information box, this is some information about this example script. we are using this to show off how things are done", InfoMessageType.WARNING)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        public float exampleFloat;
        public string exampleString;
        public bool exampleBool;
        
        [Splitter(1, 20)]
        
        [FoldoutGroup("Example Foldout Group")]
        public int exampleInt;
        [FoldoutGroup("Example Foldout Group")]
        public float exampleFloat1;
        [FoldoutGroup("Example Foldout Group 2")]
        public string exampleString2;
        [FoldoutGroup("Example Foldout Group 2")]
        public bool exampleBool3;

    }
}
