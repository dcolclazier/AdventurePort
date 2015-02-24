using Assets.Code.Scripts;

namespace Assets.Code.EventHandlers
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

        private void MouseExitedPlayerSpace(Player player)
        {
            if (_haloPrefab != null && !player.Selected) _halo.Destroy();
        }

        public void MouseEnteredPlayerSpace(Player player)
        {
            if (_haloPrefab == null && !player.Selected) 
                _haloPrefab = PrefabFactory.Instance.CreateSelectorHalo(player);
        }
   
    }
}