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


    //test stuff
    private int MoveDistance = 10;
    public bool Pathing { get; private set; }

    void Awake()
    {
        MouseHandler.Instance.Mouse3 += TestMouse3Clicked;
    
        var line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = true;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetColors(Color.white, Color.blue);
    }
    void Start ()
	{
	    _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    _mouseOver = false;
	    _currentlySelected = false;
        transform.Translate(Random.Range(-2, 2), Random.Range(-2, 2),0);

	    MouseHandler.Instance.MouseClicked += LeftMouseClicked;
        MouseHandler.Instance.MouseHeld += RightMouseHeld;
        MouseHandler.Instance.MouseReleased += RightMouseReleased;


	}

    private void LeftMouseClicked(int value, Vector3 mousePosition)
    {
        if (value != 0) return;
        if (!_mouseOver)
        {
            _currentlySelected = false;
            return;
        }
    }

    private void RightMouseReleased(int value, Vector3 mousePosition)
    {
        if (value != 1) return;
        if (_mouseOver && Pathing) ResetPath();
    }

    private void ResetPath()
    {
        if (!_mouseOver || !Pathing) return;

        var path = gameObject.GetComponent<LineRenderer>();
        path.SetVertexCount(0);
        Pathing = false;
    }

    private void RightMouseHeld(int mouseButton, Vector3 mousePosition)
    {
        if (mouseButton != 1) return;
        if (!_currentlySelected) return;

        Pathing = true;
        
        FindObjectOfType<PathTest>().DrawLine(gameObject, mousePosition, Color.white, 5.25f);
    }

    private void TestMouse3Clicked(int mouseButton, Vector3 mousePosition)
    {
        if (!_currentlySelected || mouseButton != 3) return;
        
    }

    private void MovePlayer(Vector3 startPos, Vector3 endPos)
    {
        Transform.position = Vector3.Lerp(startPos, endPos,  PlayerSpeed/100*Time.deltaTime);
    }
	void Update ()
	{
	    EnableHalo(_mouseOver || _currentlySelected);
	    EnablePathLine(_currentlySelected);

	}

    private void EnablePathLine(bool currentlySelected)
    {
        var pathline = gameObject.GetComponent<LineRenderer>();
        Pathing = pathline.enabled = currentlySelected;
    }


    

    void EnableHalo(bool enable)
    {
        var halo = transform.FindChild("selector_halo").GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, enable, null);
    }

    //void TempMovement()
    //{
    //    if (!_currentlySelected) return;

    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        transform.Translate(0, .5f, 0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        transform.Translate(0, -.5f, 0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        transform.Translate(.5f, 0, 0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        transform.Translate(-.5f, 0, 0);
    //    }
    //}
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
