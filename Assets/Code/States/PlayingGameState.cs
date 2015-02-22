using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    class PlayingGameState : IGameState
    {
        private readonly GameManager _manager;

        public PlayingGameState(GameManager manager)
        {
            _manager = manager;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _manager.CurrentState = new StartScreenState(_manager);
        }

        public void Render()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
                _manager.GameBackground);

        }
    }
}
