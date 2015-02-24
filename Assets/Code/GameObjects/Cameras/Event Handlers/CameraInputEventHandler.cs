using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class CameraInputEventHandler : IInputEventHandler
    {
        private readonly CameraManager _cameraManager;
        public CameraInputEventHandler(CameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        public void Initialize()
        {
            InputEvent.Triggers.MouseHeld += MiddleMouseHeld;
        }

        public void ClearEvents()
        {
            InputEvent.Triggers.MouseHeld -= MiddleMouseHeld;
        }

        public void RightMouseReleased(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void LeftMouseReleased(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void MiddleMouseReleased(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void RightMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void LeftMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void MiddleMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void RightMouseHeld(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void LeftMouseHeld(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void MiddleMouseHeld(MouseButton button, Vector3 mouseposition)
        {
            if (button != MouseButton.Middle) return;

            var moveDirection = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0);
            _cameraManager.Main.transform.position += moveDirection;
        }
    }
}