using System;
using System.Collections;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.States;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;

namespace Assets.Code.Scripts
{
    
    public class GameManager : MonoBehaviour
    {
        
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }
        
        public void Start()
        {
            CurrentState = new PlayingGameState(this);
        }
        public void Update ()
        {
            if (CurrentState != null) CurrentState.Update();
        }
        public void OnGUI()
        {
            if (CurrentState != null) CurrentState.Render();
        }
    
    }

    
}