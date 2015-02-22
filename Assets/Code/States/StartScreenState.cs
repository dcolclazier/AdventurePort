﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    class StartScreenState : IGameState
    {
        private readonly GameManager _manager;

        public StartScreenState(GameManager manager)
        {
            _manager = manager;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _manager.CurrentState = new PlayingGameState(_manager);
        }

        public void Render()
        {
            GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height),
                _manager.StartScreenBackground);

        }
    }
}
