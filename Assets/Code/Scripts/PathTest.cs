using System;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    private LineRenderer _circleRenderer;
    public void DrawDebugLine(Vector3 from, Vector3 to)
    {
        Debug.DrawLine(from,to,Color.white);
    }

    public void Start()
    {
        _circleRenderer = new GameObject().AddComponent<LineRenderer>();
        _circleRenderer.gameObject.name = "Pathing Circle testing";
    }

    public PathTest()
    {
        
    }

    public void DrawLine(GameObject goFrom, Vector3 to, Color color, float toOffset)
    {
        var lineRenderer = goFrom.GetComponent<LineRenderer>();

        var angleToDest = Vector2.Angle(goFrom.transform.position, to);
        Debug.Log("Angle: " + angleToDest);


        lineRenderer.SetVertexCount(2);
        lineRenderer.SetWidth(.05f,.05f);
        lineRenderer.SetColors(color,color);
        lineRenderer.SetPosition(0,goFrom.transform.position);
        lineRenderer.SetPosition(1,PointOnCircle(.25f,angleToDest,to));
        DrawCircle(to,1);
    }

    public void DrawCircle(Vector3 center, float radius)
    {
        _circleRenderer.SetVertexCount(126); 
        _circleRenderer.SetColors(Color.white,Color.white);
        _circleRenderer.SetWidth(.05f,.05f);
        var i = 0;
        for (var theta = 0f; theta < (2 * Mathf.PI); theta += .05f)
        {
            // Calculate position of point
            var x = (radius*.25f) * Mathf.Cos(theta) + center.x;
            var y = (radius*.25f) * Mathf.Sin(theta) + center.y;
            // Set the position of this point
            var pos = new Vector3(x, y, 0);
            _circleRenderer.SetPosition(i, pos);
            i++;
        }
        
    }
    
    public static Vector3 PointOnCircle(float radius, float angleInDegrees, Vector3 origin)
    {
        // Convert from degrees to radians via multiplication by PI/180        
        var x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.x;
        var y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.y;

        return new Vector3(x, y,0);
    }

    public static void DrawPlayerPath(Player player, List<Vector3> nodesAlongPath, Color color)
    {
        if (!player.Pathing) return;

        var pathLine = player.gameObject.GetComponent<LineRenderer>();

        for (var index = 0; index < nodesAlongPath.Count; index++)
        {
            pathLine.SetPosition(index,nodesAlongPath[index]);
        }


    }
    public static void DrawPlayerPath(Player player, Vector3 destination, Color color)
    {
        
    }

}