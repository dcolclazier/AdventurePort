using System;
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
        private PathInputEventHandler _pathEventHandler;
    
        private bool _visible;
        private List<PathSegment> _segments; 

        public Path(Player player)
        {
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
            if (_segments != null)
            {
                foreach (var segment in _segments)
                {

                    var test = new Vector3((mousePosition.x - segment.StartPoint.x),
                            (mousePosition.y - segment.StartPoint.y));

                    Vector3 actualPosition;
                    if (DaveMath.Length(segment.StartPoint, mousePosition) < _player.MoveDistance) actualPosition = mousePosition;
                    else
                    {
                        actualPosition = (test.normalized * _player.MoveDistance )+ segment.StartPoint;
                    }
                    segment.UpdatePoints(_player.Position,actualPosition);
                }
            }
            else
                _segments = new List<PathSegment> {new PathSegment(_player.Position, mousePosition, _player.transform)};
            //if(_segments != null) _segments.ForEach(p=>p.UpdatePoints(_player.Position,mousePosition)); 
            //else _segments = new List<PathSegment> {new PathSegment(_player.Position, mousePosition,_player.transform)};
            
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