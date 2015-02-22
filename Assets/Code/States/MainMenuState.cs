using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    class MainMenuState : IGameState
    {
        private readonly GameManager _manager;

        public MainMenuState(GameManager manager)
        {
            _manager = manager;
        }

        public void Update()
        {
           
        }

        public void Render()
        {
            

        }
    }
}
