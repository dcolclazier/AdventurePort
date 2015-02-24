using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using Assets.Code.GameObjects.Cameras;
using Assets.Code.GameStack;
using Assets.Code.GameStack.Blocks;
using Assets.Code.GameStack.Interrupts;
using Assets.Code.Scripts;

namespace Assets.Code.States
{
    internal class PlayingGameState : IGameState
    {
        private readonly GameManager _manager;
        public CameraManager CameraManager { get; set; }
        public StackManager StackManager { get; private set; }
        public PlayingGameState(GameManager manager)
        {
            _manager = manager;

            StackManager = new StackManager();
            CameraManager = new CameraManager();
         

            //Temp code to test stack operation
            var testStackBlock = new InfoBlock(_manager);
            StackManager.PushToStack(testStackBlock);
            var testInterrupt = new InfoInterrupt(StackManager) {Active = false};
            testInterrupt.Active = true;
            StackManager.PopStack();
            //end temp code
        }

        public void Update()
        {
            InputEvent.Triggers.Update();
            PlayerEvent.Triggers.Update();
        }

        public void Render()
        {
            
        }
    }
}
