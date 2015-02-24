using UnityEngine;

namespace Assets.Code.Scripts
{

    public class CameraManager
    {
        private CameraIEH _inputEventHandler;
        public Camera Main { get; private set; }
        public Camera Backup { get; private set; }

        public CameraManager()
        {
            _inputEventHandler = new CameraIEH(this);

            Main = Camera.main;
            Backup = null; // Refactor as necessary.
            
        }


    }
}