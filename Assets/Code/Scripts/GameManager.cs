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

        public event Click MouseClicked;
        public event Click MouseHeld;
        public void Start()
        {
            CurrentState = new MainMenuState(this);
            //Debug.Log("Game Manager started.");
        }
        public void Update ()
        {
            if (CurrentState != null) CurrentState.Update();

            if(Input.GetMouseButtonDown(0)) OnClick(0);
            if(Input.GetMouseButtonDown(1)) OnClick(1);
            if(Input.GetMouseButtonDown(2)) OnClick(2);

            if(Input.GetMouseButton(0)) OnHeld(0);
            if(Input.GetMouseButton(1)) OnHeld(1);
            if(Input.GetMouseButton(2)) OnHeld(2);
        }
	
        // Update is called once per frame
        public void OnGUI()
        {
            if (CurrentState != null) CurrentState.Render();
        }

        private Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
            //return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }

        public void OnClick(int button)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button, GetMousePosition());
        }

        public void OnHeld(int button)
        {
            if (MouseHeld != null) MouseHeld.Invoke(button, GetMousePosition());
        }
    }
}