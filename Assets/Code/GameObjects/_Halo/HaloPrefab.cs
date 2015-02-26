using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Player;
using UnityEngine;

namespace Assets.Code.GameObjects._Halo
{
    public class HaloPrefab : MonoBehaviour, IPrefab
    {
        private Player _player;

        void Update()
        {
            if (_player == null) return;
            gameObject.transform.position = _player.transform.position;
        }
        public void Initialize(Player player)
        {
            _player = player;
            gameObject.transform.parent = _player.transform;
        }

        public bool Enabled
        {
            set {  }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}