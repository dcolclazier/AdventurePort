using System.Collections.Generic;
using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Path.Event_Handlers;
using Assets.Code.GameObjects._Player;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.GameObjects._Path
{
    public class Path : IGameObject
    {
        private readonly Player _player;
        //private PathPrefab _pathPrefab;
        private PathInputEventHandler _pathEventHandler;
    
        private bool _visible;
        //private List<Vector3> _nodes;
        //all new code
        private List<PathSegment> _segments; 
        //end new code
        public Path(Player player)
        {
            _player = player;

            //_pathPrefab = PrefabFactory.Instance.CreatePathPrefab(player); //should come out

            _pathEventHandler = new PathInputEventHandler(this, _player);
            _pathEventHandler.Initialize();
        
            Debug.Log("Path created.");
        }

        //public void OldDraw(bool visible)
        //{
        //    Visible = visible;
        //    _pathPrefab.Draw(_nodes);
        //}

        public void Draw()
        {
            _segments.ForEach(p=>p.Draw());
        }

        public void UpdateSegments(Vector3 mousePosition)
        {
            //temp new implementation...

            //if(_segments != null) _segments.ForEach(p=>p.Destroy());
            if(_segments != null) _segments.ForEach(p=>p.UpdatePoints(_player.Position,mousePosition)); 
            else _segments = new List<PathSegment> {new PathSegment(_player.Position, mousePosition)};
            
        }

  
        //public void UpdateNodes(Vector3 mousePosition)
        //{
        //    //temp implementation - whatever pathing code goes here.
        //    _nodes = new List<Vector3>(2) {_player.Position, mousePosition};
        //    AdjustNodes();
        //}

        //private void AdjustNodes()
        //{
        //    for (var i = 0; i < _nodes.Count; i++)
        //    {
        //        if (i != 0) _nodes[i] = Art.PointOnCircle(.5f, Art.AngleTest(_nodes[i], _nodes[i - 1]), _nodes[i]);
        //    }
        //}

        public void Destroy()
        {
            _segments.ForEach(p=>p.Destroy());
            
            _player.Path = null;
            //_nodes.Clear();
        
            _pathEventHandler.ClearEvents();
            _pathEventHandler= null;

            //Object.Destroy(_pathPrefab.gameObject);
            //_pathPrefab = null;
        
        }
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                //if (_pathPrefab != null) _pathPrefab.Visible = _visible;
                if(_segments != null) _segments.ForEach(p=>p.Visible = _visible);
            }
        }
    }
}