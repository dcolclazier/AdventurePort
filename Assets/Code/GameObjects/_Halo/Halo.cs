using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Halo.Event_Handlers;
using Assets.Code.GameObjects._Halo;
using Assets.Code.GameObjects._Player;
using Assets.Code.Scripts;

namespace Assets.Code.GameObjects._Halo
{
    public class Halo : IGameObject
    {
        private HaloPrefab _haloPrefab;
        private readonly Player _player;
        private HaloPlayerEventHandler _haloPlayerEventHandler;

        public Halo(Player player)
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