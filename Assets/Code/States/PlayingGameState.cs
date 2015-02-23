using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    internal class PlayingGameState : IGameState
    {
        private readonly GameManager _manager;
        public List<GameObject> PlayerParty { get; set; }
        public int PlayerCharacterCount = 2;

        public PlayingGameState(GameManager manager)
        {
            _manager = manager;

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _manager.CurrentState = new MainMenuState(_manager);
        }

        public void Render()
        {
            
        }


    }
}
