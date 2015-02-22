using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.States
{
    public sealed class EventHandler : MonoBehaviour
    {
        private static EventHandler _instance;
        public static EventHandler Instance
        {
            get { return _instance ?? (_instance = FindObjectOfType<EventHandler>()); }
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0)) OnClick(0);
            if (Input.GetMouseButtonDown(1)) OnClick(1);
            if (Input.GetMouseButtonDown(2)) OnClick(2);

            if (Input.GetMouseButton(0)) OnHeld(0);
            if (Input.GetMouseButton(1)) OnHeld(1);
            if (Input.GetMouseButton(2)) OnHeld(2);
        }


        public event Click MouseClicked;
        public void OnClick(int button)
        {
            if (MouseClicked != null) MouseClicked.Invoke(button, GetMousePosition());
        }

        public event Click MouseHeld;
        public void OnHeld(int button)
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