using System.Security.Cryptography.X509Certificates;
using Assets.Code.States;
using UnityEngine;

public class SelectorHaloPrefab : MonoBehaviour, IPrefab
{
    private Player _player;

    void Start()
    {
        gameObject.transform.parent = _player.transform;
    }

    void Awake()
    {
        
    }

    void Update()
    {
        if (_player == null) return;
        gameObject.transform.position = _player.transform.position;
    }
    public void Initialize()
    {
        
    }
    public void Initialize(Player player)
    {
        _player = player;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}