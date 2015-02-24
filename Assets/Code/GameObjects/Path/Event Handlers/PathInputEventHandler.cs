using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.EventHandlers
{
    public class PathInputEventHandler : IInputEventHandler
    {
        private Path _path;
        private readonly Player _player;

        public PathInputEventHandler(Path path, Player player)
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
            if (_player.Selected && _player.MouseOver && _path != null)
            {
                _path.Destroy();
                _path = null;
            }
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

            if(_path != null) _path.Visible = _player.Selected;
        }

        public void MiddleMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        public void RightMouseHeld(MouseButton button, Vector3 mousePosition)
        {
            if (button != MouseButton.Right) return;

            if (_player.Selected && _player.CanMove && !_player.MouseOver)
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
        public void ClearEvents()
        {
            InputEvent.Triggers.MouseHeld -= RightMouseHeld;
            InputEvent.Triggers.MouseReleased -= RightMouseReleased;
            InputEvent.Triggers.MouseClicked -= LeftMouseClicked;
        }
    }
}