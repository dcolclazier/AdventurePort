using System;
using System.Collections.Generic;
using Assets.Code.GameObjects._Path;
using UnityEngine;

namespace Assets.Code.Abstract
{
    public static class Art //: MonoBehaviour
    {
        //private LineRenderer _circleRenderer;
        //public void Start()
        //{
        //    _circleRenderer = new GameObject().AddComponent<LineRenderer>();
        //    _circleRenderer.gameObject.name = "Pathing Circle";
        //}

        public static float AngleTest(Vector3 destination, Vector3 origin)
        {
            var angle = (180 / Math.PI) * Mathf.Atan2(origin.y - destination.y, origin.x - destination.x);

            return (float)angle;
        
        }

        public static void DrawLine(LineRenderer lr, List<Vector3> nodes, float width = .05f)
        {
            lr.SetVertexCount(nodes.Count);
            lr.SetWidth(width,width);

            
            var i = 0;
            foreach (var node in nodes)
            {
                lr.SetPosition(i,node);
                i++;
            }

        }

        public static void DrawLine(LineRenderer lr, Vector3 pointA, Vector3 pointB, float width = .05f)
        {
            lr.SetVertexCount(2);
            lr.SetWidth(width,width);

            lr.SetPosition(0,pointA);
            lr.SetPosition(1,pointB);
        }

      
        //smaller the precision, the more vertices in circle.
        public static void DrawCircle(LineRenderer lr, Vector3 center, float radius, float precision = .05f, float width = .025f)
        {
            //Calculate number of vertices based on precision
            var vertexCount = Math.Round((2f*Mathf.PI)/precision);
            lr.SetVertexCount((int)vertexCount); 
      
            lr.SetWidth(width, width);
            lr.SetColors(Color.yellow,Color.yellow);

            var vertexIndex = 0;
            for (var theta = 0f; theta < (2 * Mathf.PI); theta += precision)
            {
                // Calculate position of point
                var x = (radius) * Mathf.Cos(theta) + center.x;
                var y = (radius) * Mathf.Sin(theta) + center.y;
                // Set the position of this point
                var position = new Vector3(x, y, 0);
                lr.SetPosition(vertexIndex, position);
                vertexIndex++;
            }
        
        }
    
        public static Vector3 PointOnCircle(float radius, float angleInDegrees, Vector3 origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            var x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.x;
            var y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.y;

            return new Vector3(x, y,0);
        }
    }
}