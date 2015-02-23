using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    public sealed class MouseHandler 
    {
        private static MouseHandler _instance;
        public static MouseHandler Instance
        {
            //get { return _instance ?? (_instance = FindObjectOfType<MouseHandler>()); }
            get { return _instance ?? (_instance = new MouseHandler()); }
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0)) OnClick(0);
            if (Input.GetMouseButtonDown(1)) OnClick(1);
            if (Input.GetMouseButtonDown(2)) OnClick(2);

            if (Input.GetMouseButton(0)) OnHeld(0);
            if (Input.GetMouseButton(1)) OnHeld(1);
            if (Input.GetMouseButton(2)) OnHeld(2);

            if (Input.GetMouseButtonUp(0)) OnRelease(0);
            if (Input.GetMouseButtonUp(1)) OnRelease(1);
            if (Input.GetMouseButtonUp(2)) OnRelease(2);

            if (Input.GetKeyUp(KeyCode.Mouse3)) OnMouse3(3);
        }

        public event Click Mouse3;
        private void OnMouse3(int button)
        {
            Debug.Log("Mouse3 click");
            if (Mouse3 != null) Mouse3.Invoke(button, GetMousePosition());

        }

        public event Click MouseReleased;
        private void OnRelease(int button)
        {
            if(MouseReleased != null) MouseReleased.Invoke(button, GetMousePosition());
        }

        public event Click MouseClicked;
        private void OnClick(int button)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button, GetMousePosition());
        }

        public event Click MouseHeld;
        private void OnHeld(int button)
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