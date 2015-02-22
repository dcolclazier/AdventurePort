using System;
using System.Collections;
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
        public CameraManager CameraManager { get; set; }
        public StackManager StackManager { get; set; }
        public MouseHandler MouseManager {
            get { return MouseHandler.Instance; }
        }
        public void Start()
        {
            CameraManager = new CameraManager(this);
            CurrentState = new PlayingGameState(this);
            StackManager = new StackManager(this);
        }
       
        public void Update ()
        {
            MouseHandler.Instance.Update();
            if (CurrentState != null) CurrentState.Update();
        }
        public void OnGUI()
        {
            if (CurrentState != null) CurrentState.Render();
        }
    
    }
}