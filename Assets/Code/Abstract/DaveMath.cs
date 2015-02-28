using System;
using UnityEngine;

namespace Assets.Code.Abstract
{
    public static class DaveMath
    {
        public static Vector3 FindCircleEdge(Vector3 origin, Vector3 directionToFace, float radius)
        {
            var heading = Heading(origin, directionToFace);
            return PointOnCircle2D(radius, heading, origin);
        }
        public static Vector3 RelativeVector(Vector3 origin, Vector3 relativePoint)
        {
            var relativeVector = new Vector3((relativePoint.x - origin.x),
                            (relativePoint.y - origin.y));
            return relativeVector;
        }
        public static Vector3 OffsetVector(Vector3 origin, float xOffset = 0f, float yOffset = 0f)
        {
            var offset = new Vector3(xOffset, yOffset);
            return origin + offset;
        }
        public static double Length(Vector3 p1, Vector3 p2)
        {
            return Math.Sqrt(((p2.x-p1.x)*(p2.x-p1.x))+((p2.y-p1.y)*(p2.y-p1.y)));
        }
        private static float Heading(Vector3 origin, Vector3 destination)
        {
            var angle = (180 / Math.PI) * Mathf.Atan2(destination.y - origin.y, destination.x - origin.x);
            return (float)angle;
        }
        private static Vector3 PointOnCircle2D(float radius, float angleInDegrees, Vector3 origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            var x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.x;
            var y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.y;

            return new Vector3(x, y);
        }
    }
}