using System.Collections;
using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class GameManager : MonoBehaviour {
        
        public Texture2D StartScreenBackground;
        public Texture2D GameBackground;
        public IGameState CurrentState { get; set; }

        public void Start()
        {
            CurrentState = new StartScreenState(this);
        }
        public void Update ()
        {
            if (CurrentState != null)
                CurrentState.Update();

        }
	
        // Update is called once per frame
        public void OnGUI()
        {
            if (CurrentState != null)
                CurrentState.Render();
        }
    }
}