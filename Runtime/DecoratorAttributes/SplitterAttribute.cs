using UnityEngine;

namespace SG.SG_Inspector_Attributes.Runtime.DecoratorAttributes {
    public class SplitterAttribute : PropertyAttribute {
        public readonly int thickness;
        public readonly int padding;
        public SplitterAttribute(int thickness = 1, int padding = 0) {
            this.thickness = thickness;
            this.padding = padding;
        }
    }
}