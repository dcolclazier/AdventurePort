using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameStack.Interrupts;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    internal class PlayingGameState : IGameState
    {
        private readonly GameManager _manager;
        
        public PlayingGameState(GameManager manager)
        {
            _manager = manager;


            var testStackBlock = new InfoBlock(_manager);
            _manager.StackManager.PushToStack(testStackBlock);
            var testStackBlockInterrupt = new InfoInterrupt(_manager);
            _manager.StackManager.PopStack();


        }

        public void Update()
        {
            
        }

        public void Render()
        {
            
        }


    }
}
