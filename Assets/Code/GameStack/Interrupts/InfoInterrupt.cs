using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Code.Scripts;
using Assets.Code.States;

namespace Assets.Code.GameStack.Interrupts
{
    class InfoInterrupt : IInterrupt
    {
        private readonly StackManager _stackManager;
        public bool Active { get; set; }
        public InfoInterrupt(StackManager stackManager, bool active = true)
        {
            Active = active;
            _stackManager = stackManager;
            
            stackManager.Interrupt += InterruptAction;
        }

        public void InterruptAction(IBlock stackBlock)
        {
            if (!Active) return;

            var infoBlock = stackBlock as InfoBlock;
            if (infoBlock == null) return;

            infoBlock.InterruptMessage = "You were interrupted, info block.";
        }

        }
}
