using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Code.Scripts;

namespace Assets.Code.GameStack.Interrupts
{
    class InfoInterrupt : IInterrupt
    {
        private readonly GameManager _manager;
        public bool Active { get; set; }
        public InfoInterrupt(GameManager manager)
        {
            _manager = manager;
            Active = true;
            _manager.StackManager.Interrupt += InterruptAction;
        }

        public void InterruptAction(IBlock stackBlock)
        {
            if (!Active) return;

            var infoBlock = stackBlock as InfoBlock;
            if (infoBlock == null) return;

            infoBlock.InterruptMessage = "You were interrupted, info block.";
        }
    }

    public interface IInterrupt
    {
        bool Active { get; }
        void InterruptAction(IBlock stackBlock);
    }
}
