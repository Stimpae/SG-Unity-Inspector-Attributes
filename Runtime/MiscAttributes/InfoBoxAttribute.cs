using UnityEngine;

namespace SG.SG_Inspector_Attributes.Runtime.MiscAttributes {
    public enum InfoMessageType {
        NONE,
        INFO,
        WARNING,
        ERROR
    }
    
    public class InfoBoxAttribute : PropertyAttribute {
        public readonly string text;
        public readonly InfoMessageType messageType;

        public InfoBoxAttribute(string text, InfoMessageType messageType = InfoMessageType.INFO) {
            this.text = text;
            this.messageType = messageType;
        }
    }
}