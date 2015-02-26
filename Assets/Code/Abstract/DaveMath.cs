using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Abstract
{
    public static class DaveMath
    {
        public static float Heading(Vector3 destination, Vector3 origin)
        {
            var angle = (180 / Math.PI) * Mathf.Atan2(origin.y - destination.y, origin.x - destination.x);
            return (float)angle;
        }
        public static Vector3 OffsetVector(Vector3 origin, float x = 0f, float y = 0f)
        {
            var offset = new Vector3(x, y);
            return origin + offset;
        }
        public static Vector3 PointOnCircle2D(float radius, float angleInDegrees, Vector3 origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            var x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.x;
            var y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.y;

            return new Vector3(x, y);
        }

        public static double Length(Vector3 p1, Vector3 p2)
        {
            return Math.Sqrt(((p2.x-p1.x)*(p2.x-p1.x))+((p2.y-p1.y)*(p2.y-p1.y)));
        }
    }
}