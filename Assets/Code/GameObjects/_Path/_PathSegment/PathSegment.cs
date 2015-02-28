using Assets.Code.Abstract;
using Assets.Code.Scripts;
using UnityEngine;

namespace Assets.Code.GameObjects._Path._PathSegment
{
    public class PathSegment
    {
        

        public Vector3 StartPoint { get; private set; } //center of last turn# circle, or character if first segment
        public Vector3 EndPoint { get; private set; } //center of turn# circle

        public bool Visible { set { _pathCircle.Enabled = _pathLine.Enabled = value; } }
        public double Length { get { return DaveMath.Length(StartPoint, EndPoint); } }

        private readonly PathLinePrefab _pathLine;
        private readonly PathCirclePrefab _pathCircle;

        private readonly float _maxLength;
        private readonly float _circleRadius;

        private Vector3 _adjustedEndpoint;
        

        public PathSegment(Vector3 startPoint, Vector3 endPoint, Transform parent, float maxLength, float circleRadius)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;

            _maxLength = maxLength;
            _circleRadius = circleRadius;

            _pathLine = PrefabFactory.Instance.CreatePathLine();
            _pathLine.gameObject.transform.parent = parent;
            
            _pathCircle = PrefabFactory.Instance.CreatePathTurnCircle(_circleRadius);
            _pathCircle.gameObject.transform.parent = parent;
        }
        public void UpdateEndPoints(Vector3 startPoint, Vector3 endPoint)
        {

            StartPoint = DaveMath.FindCircleEdge(startPoint, endPoint, _circleRadius);

            var correctedLengthVector = (DaveMath.Length(StartPoint, endPoint) < _maxLength) ? endPoint :
                    (DaveMath.RelativeVector(StartPoint, endPoint).normalized * _maxLength) + StartPoint;
            
            //EndPoint = DaveMath.OffsetVector(correctedLengthVector,0f,_circleRadius);
            EndPoint = correctedLengthVector;
            _adjustedEndpoint = DaveMath.FindCircleEdge(EndPoint, StartPoint, _circleRadius);

        }
        public void Draw(Color circleColor, Color pathColorA, Color pathColorB)
        {
            _pathLine.Draw(StartPoint,_adjustedEndpoint, pathColorA, pathColorB);
            _pathCircle.Draw(EndPoint, circleColor);
        }

        public void Destroy()
        {
            _pathCircle.Destroy();
            _pathLine.Destroy();
        }
    }
}