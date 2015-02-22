using System.Collections;
using System.Collections.Generic;
using Assets.Code.States;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Scripts
{
    
    public class GameManager : MonoBehaviour
    {
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }
        private CameraManager CameraManager { get; set; }
        
        public void Start()
        {
            CameraManager = new CameraManager(this);
            CurrentState = new MainMenuState(this);
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