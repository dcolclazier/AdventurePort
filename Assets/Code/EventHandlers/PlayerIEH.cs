using System;
using Assets.Code.States;
using UnityEngine;

public class PlayerIEH : IInputEventHandler
{
    private readonly Player _player;

    

    public PlayerIEH(Player player)
    {
        
        _player = player;
        Initialize();
    }

    public void Initialize()
    {
        InputEvent.Triggers.MouseClicked += LeftMouseClicked;
        //InputEvent.Triggers.MouseHeld += RightMouseHeld;
        //InputEvent.Triggers.MouseHeld += LeftMouseHeld;
        //InputEvent.Triggers.MouseReleased += LeftMouseReleased;

        InputEvent.Triggers.MouseClicked += RightMouseClicked;
        //InputEvent.Triggers.MouseHeld += RightMouseHeld;
        //InputEvent.Triggers.MouseReleased += RightMouseReleased;
    }

    public void RightMouseReleased(MouseButton button, Vector3 mousePosition)
    {
        if (button != MouseButton.Right) return;
        
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
        if (button != MouseButton.Right) return;
        if (!_player.Selected) return;

        if (_player.CanMove)
        {
            if (_player.Path == null) _player.Path = new Path(_player);
        }
            

    }


    public void LeftMouseClicked(MouseButton button, Vector3 mouseposition)
    {
        if (button != MouseButton.Left) return;

        if (_player.Selected && !_player.MouseOver) _player.Selected = false;
        if (!_player.Selected && _player.MouseOver) _player.Selected = true;
    }

    public void MiddleMouseClicked(MouseButton button, Vector3 mousePosition)
    {
        throw new System.NotImplementedException();
    }

    public void RightMouseHeld(MouseButton button, Vector3 mousePosition)
    {
        if (button != MouseButton.Right) return;
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