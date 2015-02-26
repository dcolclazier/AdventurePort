using System;
using System.Collections.Generic;
using Assets.Code.GameObjects._Path;
using UnityEngine;

namespace Assets.Code.Abstract
{
    public static class Art 
    {
        public static void DrawLine(LineRenderer lr, Vector3 pointA, Vector3 pointB, Color colorA, Color colorB, float width = .05f)
        {
            lr.SetColors(colorA,colorB);
            lr.SetVertexCount(2);
            lr.SetWidth(width,width);

            lr.SetPosition(0,pointA);
            lr.SetPosition(1,pointB);
        }

        
        public static void DrawCircle(LineRenderer lr, Vector3 center, Color color, float radius, float precision = .05f, float width = .025f)
        {
            //smaller the precision, higher the vertex count
            var vertexCount = Math.Round((2f*Mathf.PI)/precision);
            lr.SetVertexCount((int)vertexCount); 
      
            lr.SetWidth(width, width);
            lr.SetColors(color,color);

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
    }
}