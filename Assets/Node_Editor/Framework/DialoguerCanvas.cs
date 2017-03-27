using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace NodeEditorFramework
{
    [NodeCanvasType("Dialoguer")]
    public class DialoguerCanvas : NodeCanvas
    {
        public override string canvasName { get { return "Dialoguer Canvas"; } }

        public Dictionary<string, bool> localBoolDict = new Dictionary<string, bool>();
        public Dictionary<string, float> localFloatDict = new Dictionary<string, float>();
        public Dictionary<string, string> localStringDict = new Dictionary<string, string>();
    }
}
