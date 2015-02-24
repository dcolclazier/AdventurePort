using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameStack.Blocks;
using UnityEngine;
using Assets.Code.Scripts;
using Assets.Code.States;

namespace Assets.Code.GameStack.Interrupts
{
    class InfoInterrupt : IInterrupt
    {
        private readonly StackManager _stackManager;
        private bool _active;

        public bool Active
        {
            get { return _active; }
            set
            {
                if (value) _stackManager.Interrupt += InterruptAction;
                else _stackManager.Interrupt -= InterruptAction;
                _active = value;
            }
        }
        public InfoInterrupt(StackManager stackManager, bool active = false)
        {
            
            _stackManager = stackManager;
            Active = active;
        }

        public void InterruptAction(IBlock stackBlock)
        {
            var infoBlock = stackBlock as InfoBlock;
            if (infoBlock == null) return;


            infoBlock.InterruptMessage = "You were interrupted, info block.";
        }

        }
}
