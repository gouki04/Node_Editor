using UnityEngine;
using UnityEditor;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
    [System.Serializable]
    [Node(false, "Dialoguer/Text")]
    public class TextNode : Node
    {
        public const string ID = "text";
        public override string GetID { get { return ID; } }

        public bool show_advance = false;
        public string text = "";
        public string player_name = "";

        public override Node Create(Vector2 pos)
        {
            var node = CreateInstance<TextNode>();

            node.name = "Text";
            node.rect = new Rect(pos.x, pos.y, 200, 150);

            node.CreateInput("Dialogue", "Dialogue", NodeSide.Left, 10);

            NodeOutput.Create(node, "next", "Dialogue");

            return node;
        }

        protected internal override void NodeGUI()
        {
			GUILayout.BeginHorizontal ();
            GUILayout.Label("Text:", GUILayout.Width(50));
            show_advance = EditorGUILayout.ToggleLeft("advance", show_advance, GUILayout.Width(100));
            Outputs[0].DisplayLayout();
            GUILayout.EndHorizontal();

            GUILayout.BeginVertical();

			GUILayout.BeginHorizontal ();
            GUILayout.Label("name:");
            player_name = EditorGUILayout.TextField(player_name);
            GUILayout.EndHorizontal();

            text = EditorGUILayout.TextArea(text, GUILayout.Height(80));
            if (show_advance) {
                rect.height = 150;
            }
            else {
                rect.height = 150;
            }
            GUILayout.EndVertical();
        }
    }
}