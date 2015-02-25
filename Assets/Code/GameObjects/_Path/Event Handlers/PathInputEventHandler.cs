using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using Assets.Code.GameObjects._Player;
using UnityEngine;

namespace Assets.Code.GameObjects._Path.Event_Handlers
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

            if (_player.Selected && _player.CanMove)
            {
                //_path.UpdateNodes(mousePosition);
                //_path.OldDraw(true);
           
                _path.UpdateSegments(mousePosition);
                _path.Draw();
            }
        }

    }
}