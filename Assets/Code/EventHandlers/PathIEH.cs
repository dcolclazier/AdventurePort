using Assets.Code.States;
using UnityEngine;

public class PathIEH : IInputEventHandler
{
    private readonly Path _path;
    private readonly Player _player;

    public PathIEH(Path path, Player player)
    {
        _path = path;
        _player = player;
    }

    public void Initialize()
    {
        InputEvent.Triggers.MouseHeld += RightMouseHeld;
        InputEvent.Triggers.MouseReleased += RightMouseReleased;
        InputEvent.Triggers.MouseClicked += LeftMouseClicked;
    }

    public void RightMouseReleased(MouseButton button, Vector3 mousePosition)
    {
        if (button != MouseButton.Right) return;
        if(_player.Selected && _player.MouseOver) _path.Clear();
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

    }

    public void LeftMouseClicked(MouseButton button, Vector3 mousePosition)
    {
        if (button != MouseButton.Left) return;

        _path.Visible = _player.Selected;
    }

    public void MiddleMouseClicked(MouseButton button, Vector3 mousePosition)
    {
        throw new System.NotImplementedException();
    }

    public void RightMouseHeld(MouseButton button, Vector3 mousePosition)
    {
        if (button != MouseButton.Right) return;

        if (_player.Selected && _player.CanMove)
        {
            _path.UpdateNodes(mousePosition);
            _path.Draw(true);           
        }

    }

    public void LeftMouseHeld(MouseButton button, Vector3 mousePosition)
    {
        throw new System.NotImplementedException();
    }

    public void MiddleMouseHeld(MouseButton button, Vector3 mousePosition)
    {
        throw new System.NotImplementedException();
    }
}