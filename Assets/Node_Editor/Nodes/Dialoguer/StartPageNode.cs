using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;

namespace NodeEditorFramework.Standard
{
    [System.Serializable]
    [Node(false, "Dialoguer/StartPage")]
    public class StartPageNode : Node
    {
        public const string ID = "startPage";
        public override string GetID { get { return ID; } }

        public float value = 1f;

        public override Node Create(Vector2 pos)
        {
            var node = CreateInstance<StartPageNode>();

            node.name = "Start Page";
            node.rect = new Rect(pos.x, pos.y, 100, 20);

            node.CreateOutput("Dialogue", "Dialogue", NodeSide.Right, 10);
            //NodeOutput.Create(node, "Value", "Dialogue");

            return node;
        }

        protected internal override void NodeGUI()
        {
            //OutputKnob(0);
        }
    }

    // Connection Type only for visual purposes
    public class DialgueType : IConnectionTypeDeclaration
    {
        public string Identifier { get { return "Dialogue"; } }
        public Type Type { get { return typeof(void); } }
        public Color Color { get { return Color.blue; } }
        public string InKnobTex { get { return "Textures/In_Knob.png"; } }
        public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
    }
}