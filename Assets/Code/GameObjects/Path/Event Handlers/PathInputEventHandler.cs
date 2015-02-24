using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using UnityEngine;

namespace Assets.Code.GameObjects.Path.Event_Handlers
{
    public class PathInputEventHandler : IInputEventHandler
    {
        private Path _path;
        private readonly Player.Player _player;

        public PathInputEventHandler(Path path, Player.Player player)
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
        public void ClearEvents()
        {
            InputEvent.Triggers.MouseHeld -= RightMouseHeld;
            InputEvent.Triggers.MouseReleased -= RightMouseReleased;
            InputEvent.Triggers.MouseClicked -= LeftMouseClicked;
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
        public void LeftMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            if (button != MouseButton.Left) return;

            if(_path != null) _path.Visible = _player.Selected;
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

    }
}