using UnityEngine;

public class SelectorHalo : MonoBehaviour
{
    private Player _player;

    void Start()
    {
        
    }

    public void Initialize(Player player)
    {
        _player = player;
        gameObject.transform.parent = player.transform;
        gameObject.transform.position = player.transform.position;
    }
    void Update()
    {
        if (_player == null) return;

        EnableHalo(_player.MouseOver || _player.Selected);
    }
    private void EnableHalo(bool enable)
    {
        var halo = gameObject.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, enable, null);
    }


    public void Clear()
    {
        Destroy(gameObject);
    }
}