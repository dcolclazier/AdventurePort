using System.Collections.Generic;
using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using UnityEngine;

namespace Assets.Code.GameObjects.Path
{
    public class PathPrefab : MonoBehaviour, IPrefab
    {
        private LineRenderer _pathLine;
        public bool Visible { get { return _pathLine.enabled; } set { _pathLine.enabled = value; } }
        public void Initialize(PlayerCharacter.Player player)
        {
            gameObject.transform.parent = player.transform;
            
        }
        public void Awake()
        {
            _pathLine = gameObject.AddComponent<LineRenderer>();
            _pathLine.useWorldSpace = true;
            _pathLine.sharedMaterial = new Material(Shader.Find("Particles/Additive"));   
        }

        public void Draw(List<Vector3> nodes)
        {
            Art.DrawLine(_pathLine, nodes);
        }

        public void Destroy()
        {
            _pathLine.sharedMaterial = null;
            _pathLine = null;
            Destroy(gameObject);
        }

        public void Resize(int size)
        {
            _pathLine.SetVertexCount(size);
        }


 
    }
}


