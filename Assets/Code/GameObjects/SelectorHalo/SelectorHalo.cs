using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects.PlayerCharacter;
using Assets.Code.GameObjects.SelectorHalo.Event_Handlers;
using Assets.Code.Scripts;

namespace Assets.Code.GameObjects.SelectorHalo
{
    public class SelectorHalo : IGameObject
    {
        private SelectorHaloPrefab _haloPrefab;
        private readonly Player _player;
        private HaloPlayerEventHandler _haloPlayerEventHandler;

        public SelectorHalo(Player player)
        {
            _player = player;
            _haloPrefab = PrefabFactory.Instance.CreateSelectorHalo(_player);

            _haloPlayerEventHandler = new HaloPlayerEventHandler(this, _haloPrefab, _player);
        
            _haloPlayerEventHandler.Initialize();
        }

        public void Create()
        {
            _haloPrefab = _haloPrefab = PrefabFactory.Instance.CreateSelectorHalo(_player);

        }

        public void Destroy()
        {
            _player.Halo = null;

            _haloPlayerEventHandler.ClearEvents();
            _haloPlayerEventHandler = null;

            _haloPrefab.Destroy();
        }
    }
}