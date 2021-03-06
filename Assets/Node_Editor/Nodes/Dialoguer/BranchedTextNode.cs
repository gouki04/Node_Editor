﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System.Collections.Generic;

namespace NodeEditorFramework.Standard
{
    [System.Serializable]
    [Node(false, "Dialoguer/Branched Text")]
    public class BranchedTextNode : Node
    {
        public const string ID = "branchedText";
        public override string GetID { get { return ID; } }

        public bool show_advance = false;
        public string body_text = "";
        public string player_name = "";

        [System.Serializable]
        public class Choice
        {
            public string name = "";
            public string text = "";
        }

        public const int MinChoiceCnt = 2;
        public List<Choice> choices = new List<Choice>();

        public override Node Create(Vector2 pos)
        {
            var node = CreateInstance<BranchedTextNode>();

            node.name = "Branched Text";
            node.rect = new Rect(pos.x, pos.y, 200, 220);

            node.CreateInput("Dialogue", "Dialogue", NodeSide.Left, 10);

            node.AddChoice();
            node.AddChoice();

            return node;
        }

        public void AddChoice()
        {
            var choice = new Choice();
            choice.name = "choice" + choices.Count;

            NodeOutput.Create(this, choice.name, "Dialogue");

            choices.Add(choice);
        }

        public void RemoveChoice()
        {
            if (choices.Count <= MinChoiceCnt) {
                return;
            }

            var choice = choices[choices.Count - 1];
            var output = Outputs[choices.Count - 1];
            while (output.connections.Count != 0) {
                output.connections[0].RemoveConnection();
            }

            Outputs.Remove(output);
            choices.Remove(choice);

            output.Delete();
        }

        protected internal override void NodeGUI()
        {
            GUILayout.BeginHorizontal();
            show_advance = EditorGUILayout.ToggleLeft("advance", show_advance, GUILayout.Width(80));
            if (GUILayout.Button("Add")) {
                AddChoice();
            }

            GUI.enabled = Outputs.Count > MinChoiceCnt;
            if (GUILayout.Button("Remove")) {
                RemoveChoice();
            }
            GUI.enabled = true;

            GUILayout.EndHorizontal();

            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            GUILayout.Label("name:");
            player_name = EditorGUILayout.TextField(player_name);
            GUILayout.EndHorizontal();

            body_text = EditorGUILayout.TextArea(body_text, GUILayout.Height(80));
            for (var i = 0; i < choices.Count; ++i) { 
                Outputs[i].DisplayLayout();
                choices[i].text = EditorGUILayout.TextField(choices[i].text);
            }

            rect.height = 150 + 35 * choices.Count;
            GUILayout.EndVertical();
        }
    }
}