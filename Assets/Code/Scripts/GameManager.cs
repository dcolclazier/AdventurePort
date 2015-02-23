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
        public StackManager StackManager { get; private set; }
        public void Awake()
        {
            
        }
        public void Start()
        {
            StackManager = new StackManager();
            Debug.Log("Creating camera...");
            CameraManager = new CameraManager(this);
            CurrentState = new PlayingGameState(this);
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