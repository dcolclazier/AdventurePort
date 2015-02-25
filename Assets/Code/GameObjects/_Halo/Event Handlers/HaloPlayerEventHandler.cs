using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;
using Assets.Code.GameObjects._Player;

namespace Assets.Code.GameObjects._Halo.Event_Handlers
{
    public class HaloPlayerEventHandler : IPlayerEventHandler
    {
        private readonly Halo _halo;
        private HaloPrefab _haloPrefab;
        private Player _player;


        public HaloPlayerEventHandler(Halo halo, HaloPrefab haloPrefab, Player player)
        {
            _halo = halo;
            _haloPrefab = haloPrefab;
            _player = player;
        }

        public void Initialize()
        {
            PlayerEvent.Triggers.MouseEnteredPlayerSpace += MouseEnteredPlayerSpace;
            PlayerEvent.Triggers.MouseExitedPlayerSpace += MouseExitedPlayerSpace;
        }

        public void ClearEvents()
        {
            PlayerEvent.Triggers.MouseEnteredPlayerSpace -= MouseEnteredPlayerSpace;
            PlayerEvent.Triggers.MouseExitedPlayerSpace -= MouseExitedPlayerSpace;        
        }

        private void MouseExitedPlayerSpace(Player player)
        {
            if (_player != player) return;

            if (_haloPrefab != null && !player.Selected) _halo.Destroy();
        }

        public void MouseEnteredPlayerSpace(Player player)
        {
            if (_player != player) return;

            if (_haloPrefab == null && !player.Selected) _halo.Create();

        }
   
    }
}