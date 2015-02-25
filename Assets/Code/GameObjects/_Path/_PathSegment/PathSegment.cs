using System;
using System.Collections.Generic;
using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.GameObjects._Path
{
    public class PathSegment
    {
        public Vector3 StartPoint { get; private set; } //center of last turn# circle, or character if first segment
        public Vector3 EndPoint { get; private set; } //center of turn# circle

        public bool Visible { set { _turnCircle.Enabled = _pathLine.Enabled = value; } }

        private PathLinePrefab _pathLine;
        private TurnCirclePrefab _turnCircle;

        private const float TurnCircleRadius = .25f;
        
        public PathSegment(Vector3 startPoint, Vector3 endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            _turnCircle = PrefabFactory.Instance.CreatePathTurnCircle(TurnCircleRadius);
            _pathLine = PrefabFactory.Instance.CreatePathLine();
        }

        public void UpdatePoints(Vector3 newOrigin, Vector3 newDestination)
        {
            StartPoint = newOrigin;
            EndPoint = newDestination;
        }
        public void Draw()
        {
            var heading = Art.AngleTest(EndPoint, StartPoint);
            var adjustedEndpoint = Art.PointOnCircle(_turnCircle.Radius, heading, EndPoint);
            _pathLine.Draw(StartPoint,adjustedEndpoint);
            _turnCircle.Draw(EndPoint);
        }
        public void Destroy()
        {
            _turnCircle.Destroy();
            _pathLine.Destroy();
        }
    }

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}