using UnityEditor;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public interface IBlock
    {
        void PreInterrupt();
        void PostInterrupt();
    }
}

static class PathTest
{
    public static void DrawPath(Vector3 from, Vector3 to)
    {
        Debug.DrawLine(from,to,Color.white);
    }
}