using System.Collections;
using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public delegate void Click(int button); 
    public class GameManager : MonoBehaviour {
        
        
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }
        public int PlayerSpeed;
        public event Click MouseClicked;
        public void Start()
        {
            CurrentState = new MainMenuState(this);
            Debug.Log("Game Manager started.");
        }
        public void Update ()
        {
            if (CurrentState != null) CurrentState.Update();

            if(Input.GetMouseButtonDown(0)) OnClick(0);
            if(Input.GetMouseButtonDown(1)) OnClick(1);
            if(Input.GetMouseButtonDown(2)) OnClick(2);
        }
	
        // Update is called once per frame
        public void OnGUI()
        {
            if (CurrentState != null) CurrentState.Render();
        }

        public void OnClick(int button)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button);
        }
    }
}