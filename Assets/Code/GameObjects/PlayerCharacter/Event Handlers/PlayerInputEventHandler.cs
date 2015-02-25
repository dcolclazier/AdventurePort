using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using UnityEngine;

namespace Assets.Code.GameObjects.PlayerCharacter.Event_Handlers
{
    public class PlayerInputEventHandler : IInputEventHandler
    {
        private readonly PlayerCharacter.Player _player;
        public PlayerInputEventHandler(PlayerCharacter.Player player)
        {
            _player = player;
        }
        public void Initialize()
        {
            InputEvent.Triggers.MouseClicked += LeftMouseClicked;
            InputEvent.Triggers.MouseClicked += RightMouseClicked;
        }
        public void ClearEvents()
        {
            InputEvent.Triggers.MouseClicked -= LeftMouseClicked;
            InputEvent.Triggers.MouseClicked -= RightMouseClicked;
        }
        public void RightMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            if (button != MouseButton.Right) return;
            if (!_player.Selected) return;

            if (_player.CanMove)
            {
                if (_player.Path == null) _player.Path = new Path.Path(_player);
            }
        }
        public void LeftMouseClicked(MouseButton button, Vector3 mouseposition)
        {
            if (button != MouseButton.Left) return;

            if (_player.Selected && !_player.MouseOver)
            {
                if(_player.Halo != null) _player.Halo.Destroy();
                _player.Selected = false;
            }
            if (!_player.Selected && _player.MouseOver) _player.Selected = true;
        }
    }
}