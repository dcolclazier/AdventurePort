using System.Collections;
using System.Collections.Generic;
using Assets.Code.States;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public delegate void Click(int button, Vector3 mouse_position); 
    public class GameManager : MonoBehaviour
    {

       
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }

        public event Click MouseClicked;
        public event Click MouseHeld;
        public void Start()
        {
            CurrentState = new MainMenuState(this);
            Debug.Log("Game Manager started.");
        }
        public void Update ()
        {
            if (CurrentState != null) CurrentState.Update();

            if(Input.GetMouseButtonDown(0)) OnClick(0, GetMousePosition());
            if(Input.GetMouseButtonDown(1)) OnClick(1, GetMousePosition());
            if(Input.GetMouseButtonDown(2)) OnClick(2, GetMousePosition());

            //while (Input.GetMouseButton(0))
            //{
            //    OnHeld(0, GetMousePosition());
            //}
            if(Input.GetMouseButton(1)) OnHeld(1,GetMousePosition());
        }
	
        // Update is called once per frame
        public void OnGUI()
        {
            if (CurrentState != null) CurrentState.Render();
        }

        private Vector3 GetMousePosition()
        {
            return new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }

        public void OnClick(int button, Vector3 mousePosition)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button, mousePosition);
        }

        public void OnHeld(int button, Vector3 mousePosition)
        {
            if (MouseHeld != null) MouseHeld.Invoke(button, mousePosition);
        }
    }
}