using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using UnityEngine;

namespace Assets.Code.GameObjects._Cameras.Event_Handlers
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
        public void MiddleMouseHeld(MouseButton button, Vector3 mouseposition)
        {
            if (button != MouseButton.Middle) return;

            var moveDirection = new Vector3(-Input.GetAxis("Mouse X")*.6f, -Input.GetAxis("Mouse Y")*.6f, 0);
            _cameraManager.Main.transform.position += moveDirection;
        }
    }
}