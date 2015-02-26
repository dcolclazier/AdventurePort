using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Path.Event_Handlers;
using Assets.Code.GameObjects._Path._PathSegment;
using Assets.Code.GameObjects._Player;
using UnityEngine;

namespace Assets.Code.GameObjects._Path
{
    public class Path : IGameObject
    {
        
        private readonly Player _player;
        private PathInputEventHandler _pathEventHandler;
    
        private bool _visible;
        private List<PathSegment> _segments;
        private readonly float _pathCircleRadius;

        public Path(Player player)
        {
            _pathCircleRadius = .25f;

            _player = player;
            _pathEventHandler = new PathInputEventHandler(this, _player);
            _pathEventHandler.Initialize();
        
        }
        public void Draw()
        {
            _segments.ForEach(p=>p.Draw());
        }
        public void UpdateSegments(Vector3 mousePosition)
        {
            if (_segments == null)
            {
                _segments = new List<PathSegment> { new PathSegment(_player.Position, mousePosition, _player.transform, _player.MoveDistance, _pathCircleRadius) };
                return;
            }
            
            double totalSegmentLength = 0;
            for (var x = 0; x < _segments.Count; x++)
            {
                totalSegmentLength += _segments[x].Length;
                _segments[x].UpdateEndPoints(x == 0 ? _player.Position : _segments[x - 1].EndPoint, mousePosition);
            }

            var lengthToMouse = DaveMath.Length(_player.Position, mousePosition);
            var expectedSegmentCount = Math.Ceiling(lengthToMouse/_player.MoveDistance);

            if (totalSegmentLength <= lengthToMouse && _segments.Count < expectedSegmentCount)
            {
                _segments.Add(new PathSegment(_segments.Last().EndPoint, mousePosition, _player.transform, _player.MoveDistance, _pathCircleRadius));
            }
            else if(_segments.Count > expectedSegmentCount)
            {
                _segments.Last().Destroy();
                _segments.RemoveAt(_segments.Count-1);
            }

            
            
        }
        public void Destroy()
        {
            _segments.ForEach(p=>p.Destroy());
            
            _player.Path = null;
        
            _pathEventHandler.ClearEvents();
            _pathEventHandler= null;
        
        }
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                if(_segments != null) _segments.ForEach(p=>p.Visible = _visible);
            }
        }
    }
}