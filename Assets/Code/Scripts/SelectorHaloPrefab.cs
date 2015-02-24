using UnityEngine;

public class SelectorHaloPrefab : MonoBehaviour
{
    private Player _myPlayer;

    private void Start()
    {
        _myPlayer = GetComponentInParent<Player>();
    }

    private void Update()
    {
        EnableHalo(_myPlayer.MouseOver || _myPlayer.Selected);
    }

    private void EnableHalo(bool enable)
    {
        var halo = gameObject.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, enable, null);
    }


}