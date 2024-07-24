using UnityEngine;

namespace TTG.Attributes.Examples {
    [CreateAssetMenu(fileName = "ExampleScriptable", menuName = "TTG/Attributes/Examples/ExampleScriptable")]
    public class ExampleScriptable : ScriptableObject {
        [Splitter(1, 20)]
        [Title("Example Title", "Example Subtitle", TitleAlignment.LEFT, true, true)]
        [Holder] public DecoratorHolder decoratorHolder;
        
        [InfoBox("Groups and buttons will always be displayed at the button of the inspector due to the way it is constructed in the editor.", EInfoMessageType.NONE)]
        [Holder] public DecoratorHolder infoBox;
        
        [FoldoutGroup("Example Foldout Group",5)] public int exampleInt;
        [FoldoutGroup("Example Foldout Group")] public float exampleFloat1;
    }
}