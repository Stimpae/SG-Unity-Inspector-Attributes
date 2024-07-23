using System.ComponentModel;
using UnityEngine;

namespace TTG.Attributes.Examples {
    public class ExampleScript : MonoBehaviour {
        
        [ReadOnly] public string exampleReadOnlyString;

        [Label("Example Label", true)] public string exampleLabelString;
        [Label()] public string exampleLabelString2;

        [InfoBox("Example information box, this is some information about this example script. we are using this to show off how things are done", EInfoMessageType.WARNING)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        public float exampleFloat;
        public string exampleString;
        public bool exampleBool;
        
        [Splitter(1, 20)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        [Holder] public DecoratorHolder decoratorHolder;
        
        [ButtonField(nameof(ExampleMethod), "Example Button Field", 30)]
        [Holder] public DecoratorHolder decoratorHolder2;

        [InfoBox("Groups and buttons will always be displayed at the button of the inspector due to the way it is constructed in the editor.", EInfoMessageType.NONE)]
        [Holder] public DecoratorHolder infoBox;
        
        [FoldoutGroup("Example Foldout Group",3)] public int exampleInt;
        [FoldoutGroup("Example Foldout Group",3)] public float exampleFloat1;
        
        [FoldoutGroup("Example Foldout Group 2", 1)] public string exampleString2;
        [FoldoutGroup("Example Foldout Group 2",1)] public bool exampleBool3;
        
        [BoxGroup("Example Box Group", 2)] public string exampleString4;
        [BoxGroup("Example Box Group", 2)] public bool exampleBool5;
        
        [Button("Example Button")]
        public void ExampleMethod() {
            Debug.Log("Example Method Called");
        }
    }
}
