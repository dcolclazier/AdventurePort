using Assets.Code.EventHandlers;
using Assets.Code.Scripts;

public class SelectorHalo
{
    private SelectorHaloPrefab _haloPrefab;
    //private readonly Player _player;
    private readonly Player _player;
    private HaloPlayerEventHandler _haloPlayerEventHandler;
    private HaloInputEventHandler _haloInputHandler;

    public SelectorHalo(Player player)
    {
        _player = player;
        _haloPrefab = PrefabFactory.Instance.CreateSelectorHalo(_player);

        _haloInputHandler = new HaloInputEventHandler(this);
        _haloPlayerEventHandler = new HaloPlayerEventHandler(this, _haloPrefab);
        
        _haloPlayerEventHandler.Initialize();
        _haloInputHandler.Initialize();
    }

    public void CreateHalo()
    {
        _haloPrefab = _haloPrefab = PrefabFactory.Instance.CreateSelectorHalo(_player);

    }

    public void Destroy()
    {
        _player.Halo = null;
        _haloInputHandler.ClearEvents();
        _haloInputHandler = null;

        _haloPlayerEventHandler.ClearEvents();
        _haloPlayerEventHandler = null;

        _haloPrefab.Destroy();
    }
}