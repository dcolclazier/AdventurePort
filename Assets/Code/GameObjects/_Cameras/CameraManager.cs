using Assets.Code.GameObjects._Cameras.Event_Handlers;
using UnityEngine;

namespace Assets.Code.GameObjects._Cameras
{

    public class CameraManager
    {
        private CameraInputEventHandler _inputEventHandler;
        public Camera Main { get; private set; }
        public Camera Backup { get; private set; }

        public CameraManager()
        {
            _inputEventHandler = new CameraInputEventHandler(this);
            _inputEventHandler.Initialize();
            Main = Camera.main;
            Backup = null; // Refactor as necessary.
            
        }


    }
}