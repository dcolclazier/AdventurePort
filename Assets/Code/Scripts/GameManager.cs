using System.Collections;
using System.Collections.Generic;
using Assets.Code.States;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public delegate void Click(int button, Vector3 mousePosition); 
    public class GameManager : MonoBehaviour
    {
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }
        
        public void Start()
        {
            CurrentState = new MainMenuState(this);
            EventHandler.Instance.MouseHeld += MiddleMouseHeld;
        }
        private void MiddleMouseHeld(int button, Vector3 mouseposition)
        {
            if (button != 2) return;
 
            var moveDirection = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0);
            Camera.main.transform.position += moveDirection;
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