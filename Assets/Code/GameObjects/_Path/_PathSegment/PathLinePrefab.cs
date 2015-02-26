using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using UnityEngine;

namespace Assets.Code.GameObjects._Path._PathSegment
{
    public class PathLinePrefab : MonoBehaviour, IPrefab
    {
        private LineRenderer _pathLine;

        public bool Enabled
        {
            set { _pathLine.enabled = value; }
        }

        public void Awake()
        {
            _pathLine = gameObject.AddComponent<LineRenderer>();
            _pathLine.useWorldSpace = true;
            _pathLine.sharedMaterial = new Material(Shader.Find("Particles/Additive")); ;
        }

        public void Destroy()
        {
            _pathLine.sharedMaterial = null;            
            _pathLine = null;
            Destroy(gameObject);
        }

        public void Draw(Vector3 origin, Vector3 destination)
        {
            Art.DrawLine(_pathLine, origin, destination);        
        }
    }
}