using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Delegates;
using UnityEngine;

namespace Assets.Code.Events
{
    public sealed class InputEvent : IEvent 
    {
        private static InputEvent _instance;
        public static InputEvent Triggers 
        {
            get { return _instance ?? (_instance = new InputEvent()); }
        }
        public void Update()
        {
            if (Input.GetMouseButtonDown(0)) OnClick(MouseButton.Left);
            if (Input.GetMouseButtonDown(1)) OnClick(MouseButton.Right);
            if (Input.GetMouseButtonDown(2)) OnClick(MouseButton.Middle);

            if (Input.GetMouseButton(0)) OnHold(MouseButton.Left);
            if (Input.GetMouseButton(1)) OnHold(MouseButton.Right);
            if (Input.GetMouseButton(2)) OnHold(MouseButton.Middle);

            if (Input.GetMouseButtonUp(0)) OnRelease(MouseButton.Left);
            if (Input.GetMouseButtonUp(1)) OnRelease(MouseButton.Right);
            if (Input.GetMouseButtonUp(2)) OnRelease(MouseButton.Middle);
        }

        public event ClickTrigger MouseReleased;
        private void OnRelease(MouseButton button)
        {
            if(MouseReleased != null) MouseReleased.Invoke(button, GetMousePosition());
        }

        public event ClickTrigger MouseClicked;
        private void OnClick(MouseButton button)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button, GetMousePosition());
        }

        public event ClickTrigger MouseHeld;
        private void OnHold(MouseButton button)
        {
            if (MouseHeld != null) MouseHeld.Invoke(button, GetMousePosition());
        }

        private Vector3 GetMousePosition()
        {
            var newVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            return new Vector3(newVector.x, newVector.y, 0);
        }
    }
}