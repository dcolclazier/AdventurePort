using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class CameraManager
    {
        public Camera Main { get; private set; }
        public Camera Backup { get; private set; }
        private GameManager _manager;

        public CameraManager(GameManager manager)
        {
            _manager = manager;

            Main = Camera.main;
            Backup = null; // Refactor as necessary.

            InitCameras();
        }

        private void InitCameras()
        {
            MouseHandler.Instance.MouseHeld += MiddleMouseHeld;
        }
        private void MiddleMouseHeld(int button, Vector3 mouseposition)
        {
            if (button != 2) return;

            var moveDirection = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0);
            Camera.main.transform.position += moveDirection;
        }

    }
}