using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Assets.Code.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

public class Path
{
    public PathPrefab PathPrefab { get; private set; }
    private readonly Player _player;
    private bool _visible;

    
    //temp
    private Vector3 _destination;
    private List<Vector3> _nodes;

    public bool Visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            if(PathPrefab != null)
                PathPrefab.Visible = _visible;
        }
    }
    public Path(Player player)
    {
        _player = player;
        var pathEventHandler = new PathIEH(this, _player);
        pathEventHandler.Initialize();
    }

    public void Draw(bool visible)
    {
        if (PathPrefab == null) PathPrefab = PrefabFactory.Instance.CreatePathPrefab(_player);
        
        Visible = visible;
        PathPrefab.Draw(_nodes);
    }

    public void UpdateNodes(Vector3 mousePosition)
    {
        //temp implementation - whatever pathing code goes here.
        _destination = mousePosition;
        _nodes = new List<Vector3>(3) {_player.Transform.position, _destination};
    }

    ~Path()
    {
       Object.Destroy(PathPrefab.gameObject);
    }

    public void Clear()
    {
        if(_nodes!=null)_nodes.Clear();
        Object.Destroy(PathPrefab.gameObject);
        PathPrefab = null;

    }
}