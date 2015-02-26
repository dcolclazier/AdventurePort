using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Player;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.GameObjects._Path
{
    public class PathSegment
    {
        private const float TurnCircleRadius = .20f;

        public Vector3 StartPoint { get; private set; } //center of last turn# circle, or character if first segment
        public Vector3 EndPoint { get; private set; } //center of turn# circle

        public double Length { get { return DaveMath.Length(StartPoint, EndPoint); } }
        public bool Visible { set { _pathCircle.Enabled = _pathLine.Enabled = value; } }

        private readonly PathLinePrefab _pathLine;
        private readonly PathCirclePrefab _pathCircle;
        private Vector3 _offsetPoint;
        
        public PathSegment(Vector3 startPoint, Vector3 endPoint, Transform parent)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            _pathCircle = PrefabFactory.Instance.CreatePathTurnCircle(TurnCircleRadius);
            _pathLine = PrefabFactory.Instance.CreatePathLine();
            _pathLine.gameObject.transform.parent = parent;
            _pathCircle.gameObject.transform.parent = parent;
        }
        public void UpdatePoints(Vector3 newOrigin, Vector3 newDestination)
        {
            StartPoint = newOrigin;
            
            EndPoint = DaveMath.OffsetVector(newDestination,0f,TurnCircleRadius);
            _offsetPoint = OffsetPathLine(EndPoint, TurnCircleRadius);
        }
        public void Draw()
        {
            _pathLine.Draw(StartPoint,_offsetPoint);
            _pathCircle.Draw(EndPoint);
        }
        private Vector3 OffsetPathLine(Vector3 center, float radius)
        {
            var heading = DaveMath.Heading(EndPoint, StartPoint);
            return  DaveMath.PointOnCircle2D(radius, heading, center);
        }
        public void Destroy()
        {
            _pathCircle.Destroy();
            _pathLine.Destroy();
        }
    }
}