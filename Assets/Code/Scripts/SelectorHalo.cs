using UnityEngine;

class SelectorHalo : MonoBehaviour
{
    private Player _myPlayer;
    void Start()
    {
        _myPlayer = GetComponentInParent<Player>();
    }
    void Update()
    {
        EnableHalo(_myPlayer.MouseOver || _myPlayer.Selected);
    }
    private void EnableHalo(bool enable)
    {
        var halo = gameObject.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, enable, null);
    }
    
}