using System;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public static class Art //: MonoBehaviour
{
    //private LineRenderer _circleRenderer;
    //public void Start()
    //{
    //    _circleRenderer = new GameObject().AddComponent<LineRenderer>();
    //    _circleRenderer.gameObject.name = "Pathing Circle";
    //}

    private static float AngleTest(Vector3 pos1, Vector3 pos2)
    {
        var angle = Mathf.Atan2(pos2.y, pos2.x) - Mathf.Atan2(pos1.y, pos1.x);
        var heading = pos2 - pos1;
        Debug.Log("Heading: x: " + heading.x + ", y: " + heading.y + ", z: " + heading.z);
        if (Math.Abs(angle) > 180) angle -= (float)(360.0 * Math.Sign(angle));

        return angle;
        
    }

    public static void DrawLine(LineRenderer lr, Vector3 from, Vector3 to, Color color, float toOffset)
    {
        //var lineRenderer = goFrom.GetComponent<LineRenderer>();

        var angleToDest = AngleTest(from,to);
        //var angleToDest = Vector2.Angle(to, goFrom.transform.position);
        Debug.Log("Angle: " + angleToDest);

        lr.SetVertexCount(2);
        lr.SetWidth(.0125f,.0125f);
        lr.SetColors(color,color);
        
        lr.SetPosition(0,from);
        lr.SetPosition(1,PointOnCircle(.25f,angleToDest,to));
        
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

    //smaller the precision, the more vertices in circle.
    public static void DrawCircle(LineRenderer lr, Vector3 center, float radius, float precision = .05f, float width = .025f)
    {
        //Calculate number of vertices based on precision
        var vertexCount = Math.Round((2f*Mathf.PI)/precision);
        lr.SetVertexCount((int)vertexCount); 
      
        lr.SetWidth(width, width);
        lr.SetColors(Color.black,Color.blue);

        var vertexIndex = 0;
        for (var theta = 0f; theta < (2 * Mathf.PI); theta += precision)
        {
            // Calculate position of point
            var x = (radius*.25f) * Mathf.Cos(theta) + center.x;
            var y = (radius*.25f) * Mathf.Sin(theta) + center.y;
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