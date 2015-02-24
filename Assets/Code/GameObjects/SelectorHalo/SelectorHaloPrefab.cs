using Assets.Code.Abstract.Interfaces;
using UnityEngine;

namespace Assets.Code.GameObjects.SelectorHalo
{
    public class SelectorHaloPrefab : MonoBehaviour, IPrefab
    {
        private Player.Player _player;

        void Update()
        {
            if (_player == null) return;
            gameObject.transform.position = _player.transform.position;
        }
        public void Initialize(Player.Player player)
        {
            _player = player;
            gameObject.transform.parent = _player.transform;
        }
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}