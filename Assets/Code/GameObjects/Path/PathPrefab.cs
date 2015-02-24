using System;
using System.Collections.Generic;
using System.Collections;
using Assets.Code.States;
using UnityEngine;
using Object = UnityEngine.Object;

public class PathPrefab : MonoBehaviour, IPrefab
{
    private LineRenderer _pathLine;
    public bool Visible { get { return _pathLine.enabled; } set { _pathLine.enabled = value; } }
    public void Initialize()
    {
        
    }
    public void Initialize(Player player)
    {
        gameObject.transform.parent = player.transform;
        Initialize();
    }
    public void Awake()
    {
        _pathLine = gameObject.AddComponent<LineRenderer>();
        _pathLine.useWorldSpace = true;
        _pathLine.sharedMaterial = new Material(Shader.Find("Particles/Additive"));   
    }

    public void Draw(List<Vector3> nodes)
    {
        Art.DrawLine(_pathLine, nodes);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Resize(int size)
    {
        _pathLine.SetVertexCount(size);
    }


 
}


