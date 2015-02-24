using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Assets.Code.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

public class Path
{
    private readonly Player _player;
    private PathPrefab _pathPrefab;
    
    private bool _visible;
    private List<Vector3> _nodes;

    public bool Visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            if(_pathPrefab != null) _pathPrefab.Visible = _visible;
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
        if (_pathPrefab == null) _pathPrefab = PrefabFactory.Instance.CreatePathPrefab(_player);
        
        Visible = visible;
        _pathPrefab.Draw(_nodes);
    }

    public void UpdateNodes(Vector3 mousePosition)
    {
        //temp implementation - whatever pathing code goes here.
        _nodes = new List<Vector3>(3) {_player.Position, mousePosition};
    }
    public void Clear()
    {
        if(_nodes!=null)_nodes.Clear();
        if (_pathPrefab != null)
        {
            Object.Destroy(_pathPrefab.gameObject);
            _pathPrefab = null;
        }
        

    }
}