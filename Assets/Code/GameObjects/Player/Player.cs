﻿using Assets.Code.Events;
using Assets.Code.GameObjects.Player.Event_Handlers;
using UnityEngine;

namespace Assets.Code.GameObjects.Player
{
    public class Player : MonoBehaviour
    {
        #region UnityFields
        //public Transform Transform;
        public float PlayerSpeed;
        #endregion
    
        public bool Moving { get; set; }
        public bool Selected { get; set; }
        public bool CanMove { get; set; }
        public bool MouseOver { get; set; }
        public Vector3 Position { get { return gameObject.transform.position; } }

        //test stuff
        public int MoveDistance { get; set; }
        public Path.Path Path { get; set; }

        public SelectorHalo.SelectorHalo Halo { get; set; }
 
        void Awake()
        {
            var inputEventHandler = new PlayerInputEventHandler(this);
            inputEventHandler.Initialize();
        
            Path = null;
            MoveDistance = 10;
            CanMove = true;
        }
        void Start ()
        {
	    
            transform.Translate(Random.Range(-2, 2), Random.Range(-2, 2),0);

        }
        private void Move(Vector3 startPos, Vector3 endPos)
        {
            if (!CanMove) return;

            gameObject.transform.position = Vector3.Lerp(startPos, endPos,  PlayerSpeed/100*Time.deltaTime);
        }
        void Update ()
        {
       
        }
    
        void OnMouseOver()
        {
            MouseOver = true;
            PlayerEvent.Triggers.OnMouseEntered(this);

            //should this go somewhere else?
            if (Halo == null) Halo = new SelectorHalo.SelectorHalo(this);
        }
        private void OnMouseExit()
        {
            MouseOver = false;
            PlayerEvent.Triggers.OnMouseLeft(this);
        }
    }
}