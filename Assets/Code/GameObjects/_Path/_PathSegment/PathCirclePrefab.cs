using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using UnityEngine;

namespace Assets.Code.GameObjects._Path
{
    public class PathCirclePrefab : MonoBehaviour, IPrefab
    {
        private LineRenderer _turnCircle;
        public float Radius { get; private set; }

        public bool Enabled
        {
            set { _turnCircle.enabled = value; }
        }

        public void Awake()
        {
            _turnCircle = gameObject.AddComponent<LineRenderer>();
            _turnCircle.useWorldSpace = true;
            _turnCircle.sharedMaterial = new Material(Shader.Find("Particles/Additive"));
            Radius = 1;
        }
        public void Draw(Vector3 position)
        {
            Art.DrawCircle(_turnCircle, position, Radius);
        }
        public void Destroy()
        {
            _turnCircle.sharedMaterial = null;
            _turnCircle = null;
            Destroy(gameObject);
        }

        public void Initialize(float radius)
        {
            Radius = radius;
        }
    }
}