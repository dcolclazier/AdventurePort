using UnityEngine;
using System.Collections;
using Assets.Code.Scripts;
using Assets.Code.States;

public class Player : MonoBehaviour
{
    #region UnityFields
    public SpriteRenderer Sprite;
    public Transform Transform;
    public float PlayerSpeed;
    #endregion

    private GameManager _manager;
    private bool _mouseOver;
    private bool _currentlySelected;
    private bool currentlyMoving = false;

    void Awake()
    {
        MouseHandler.Instance.Mouse3 += TestMouse3Clicked;
    }
    void Start ()
	{
	    _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    _mouseOver = false;
	    _currentlySelected = false;
        transform.Translate(Random.Range(-2, 2), Random.Range(-2, 2),0);

	    MouseHandler.Instance.MouseClicked += LeftMouseClicked;
        MouseHandler.Instance.MouseHeld += RightMouseHeld;

        

	}

    private void LeftMouseClicked(int value, Vector3 mousePosition)
    {
        if (!_mouseOver && value == 0) _currentlySelected = false;
        currentlyMoving = true;
    }

    private void RightMouseHeld(int value, Vector3 mousePosition)
    {
        if (!_currentlySelected || value != 1) return;
        MovePlayer(transform.position, mousePosition);
    }

    private void TestMouse3Clicked(int value, Vector3 mousePosition)
    {
        if (!_currentlySelected || value != 3) return;
        
    }

    private void MovePlayer(Vector3 startPos, Vector3 endPos)
    {
        Transform.position = Vector3.Lerp(startPos, endPos,  PlayerSpeed/100*Time.deltaTime);
    }
	void Update ()
	{
	    EnableHalo(_mouseOver || _currentlySelected);
        TempMovement();
	}

    void TestMove(Vector3 startPos, Vector3 endPos)
    {
        
    }

    

    void EnableHalo(bool enable)
    {
        var halo = transform.FindChild("selector_halo").GetComponent("Halo");
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
}
