using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DialoguerCore
{
    public class CustomConditionPhase : AbstractDialoguePhase
    {
        public readonly string message;
        public readonly string metadata;

        public CustomConditionPhase(string message, string metadata, List<int?> outs) : base(outs)
        {
            this.message = message;
            this.metadata = metadata;
        }

        protected override void onStart()
        {
            if (DialoguerEventManager.dispatchOnCondition(message, metadata)) {
                Continue(0);
            }
            else {
                Continue(1);
            }

            state = PhaseState.Complete;
        }

        override public string ToString()
        {
            return "Custon Message Phase" +
                "\nMessage: " + this.message +
                "\nMetadata: " + this.metadata +
                "\n";
        }
    }
}
