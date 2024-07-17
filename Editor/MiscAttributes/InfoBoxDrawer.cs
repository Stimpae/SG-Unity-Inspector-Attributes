using SG.SG_Inspector_Attributes.Runtime.MiscAttributes;
using UnityEditor;
using UnityEngine;

namespace SG.SG_Inspector_Attributes.Editor.MiscAttributes {
    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxDrawer : DecoratorDrawer {
        public override void OnGUI(Rect position) {
            base.OnGUI(position);
            var infoBoxAttribute = (InfoBoxAttribute)attribute;
            
            GUIStyle style = new GUIStyle(EditorStyles.helpBox) {
                richText = true,
                wordWrap = true
            };
            
            /*style.normal.textColor = infoBoxAttribute.messageType switch {
                InfoMessageType.INFO => new Color(0.24f, 0.5f, 0.9f),
                InfoMessageType.WARNING => new Color(0.9f, 0.7f, 0.1f),
                InfoMessageType.ERROR => new Color(0.9f, 0.1f, 0.1f),
                _ => style.normal.textColor
            };*/
            
            var content = new GUIContent(infoBoxAttribute.text, GetMessageTypeIcon(infoBoxAttribute.messageType));
            EditorGUI.LabelField(new Rect(position.x, position.y + 5f, position.width, position.height - 5f), content, style);
        }

        public override float GetHeight() {
            return 45f; // hmm
        }

        private Texture2D GetMessageTypeIcon(InfoMessageType type) {
            switch (type) {
                case InfoMessageType.WARNING:
                    return EditorGUIUtility.IconContent("console.warnicon").image as Texture2D;
                case InfoMessageType.ERROR:
                    return EditorGUIUtility.IconContent("console.erroricon").image as Texture2D;
                case InfoMessageType.INFO:
                case InfoMessageType.NONE:
                default:
                    return EditorGUIUtility.IconContent("console.infoicon").image as Texture2D;
            }
        }
    }
}