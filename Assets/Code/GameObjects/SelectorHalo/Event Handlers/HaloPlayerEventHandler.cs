using Assets.Code.Abstract.Interfaces;
using Assets.Code.Events;

namespace Assets.Code.GameObjects.SelectorHalo.Event_Handlers
{
    public class HaloPlayerEventHandler : IPlayerEventHandler
    {
        private readonly SelectorHalo _halo;
        private SelectorHaloPrefab _haloPrefab;


        public HaloPlayerEventHandler(SelectorHalo halo, SelectorHaloPrefab haloPrefab)
        {
            _halo = halo;
            _haloPrefab = haloPrefab;
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

        private void MouseExitedPlayerSpace(Player.Player player)
        {
            if (_haloPrefab != null && !player.Selected) _halo.Destroy();
        }

        public void MouseEnteredPlayerSpace(Player.Player player)
        {
            if (_haloPrefab == null && !player.Selected) _halo.CreateHalo();

        }
   
    }
}