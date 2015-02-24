using Assets.Code.States;
using UnityEngine;

interface IInputEventHandler
{
    void Initialize();
    void RightMouseReleased(MouseButton button, Vector3 mousePosition);
    void LeftMouseReleased(MouseButton button, Vector3 mousePosition);
    void MiddleMouseReleased(MouseButton button, Vector3 mousePosition);
    void RightMouseClicked(MouseButton button, Vector3 mousePosition);
    void LeftMouseClicked(MouseButton button, Vector3 mousePosition);
    void MiddleMouseClicked(MouseButton button, Vector3 mousePosition);
    void RightMouseHeld(MouseButton button, Vector3 mousePosition);
    void LeftMouseHeld(MouseButton button, Vector3 mousePosition);
    void MiddleMouseHeld(MouseButton button, Vector3 mousePosition);
}