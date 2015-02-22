using UnityEngine;
using System.Collections;
using Assets.Code.Scripts;
using Assets.Code.States;

public class PlayerChar : MonoBehaviour {
    private GameManager _manager;
    private bool _mouseOver;
    private bool _currentlySelected;
    // Use this for initialization
	void Start ()
	{
	    _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    _mouseOver = false;
	    _currentlySelected = false;

	    _manager.MouseClicked += LeftMouseClicked;
	}

    private void LeftMouseClicked(int value)
    {
        if (!_mouseOver) _currentlySelected = false;
    }

    // Update is called once per frame
	void Update ()
	{
	    EnableHalo(_mouseOver || _currentlySelected);
        TempMovement();
	}

    private void OnMouseDown()
    {
        _currentlySelected = true;        
    }

    void OnMouseOver()
    {
        _mouseOver = true;
    }

    private void OnMouseExit()
    {
       _mouseOver = false;
    }

    void EnableHalo(bool enable)
    {
        var halo = GameObject.Find("selector_halo").GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, enable, null);
    }

    void TempMovement()
    {
        if (!_currentlySelected) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, .5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(.5f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-.5f, 0, 0);
        }
    }
}
