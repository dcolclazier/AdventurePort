using UnityEngine;
using System.Collections;
using Assets.Code.Scripts;
using Assets.Code.States;

public class PlayerChar : MonoBehaviour
{

    public SpriteRenderer Sprite;
    public Transform Transform;

    public float PlayerSpeed;

    private GameManager _manager;
    private bool _mouseOver;
    private bool _currentlySelected;
    // Use this for initialization
 

    //lerping stuff test
    
    bool currentlyMoving = false;
    void Start ()
	{
	    _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    _mouseOver = false;
	    _currentlySelected = false;
        transform.Translate(Random.Range(-2, 2), Random.Range(-2, 2),0);
	    _manager.MouseClicked += LeftMouseClicked;
        _manager.MouseHeld += LeftMouseHeld;

	}

    private void LeftMouseClicked(int value, Vector3 mousePosition)
    {
        if (!_mouseOver && value == 0) _currentlySelected = false;
        currentlyMoving = true;

        Debug.Log("Currently Selected: " + _currentlySelected);
        Debug.Log("MouseOver:  " + _mouseOver);
    }

    private void LeftMouseHeld(int value, Vector3 mousePosition)
    {
        if (!_currentlySelected || value != 1) return;

        MovePlayer(transform.position, Camera.main.ScreenToWorldPoint(mousePosition));
        


    }

    private void MovePlayer(Vector3 startPos, Vector3 endPos)
    {
        float lerpTime = 1f;
        float currentLerpTime = 0;
        float moveDistance = 10f;

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) currentLerpTime = lerpTime;
        float perc = currentLerpTime/lerpTime;
        Transform.position = Vector3.Lerp(startPos, new Vector3(endPos.x,endPos.y,0),  PlayerSpeed/100*Time.deltaTime);


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
        var myhalo = transform.FindChild("selector_halo").GetComponent("Halo");
        //var halo = GameObject.Find("selector_halo").GetComponent("Halo");
        myhalo.GetType().GetProperty("enabled").SetValue(myhalo, enable, null);
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
