using UnityEngine;
using System.Collections;
using System.ComponentModel;
using Assets.Code.Scripts;
using Assets.Code.States;


public class Player : MonoBehaviour
{
    #region UnityFields
    //public Transform Transform;
    public float PlayerSpeed;
    #endregion

    public bool Moving { get; set; }
    public bool Pathing { get; private set; }
    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        set
        {
            if(!value) 
                if (SelectorHalo != null) SelectorHalo.Clear();
            _selected = value;
        } 
    }

    public bool CanMove { get; set; }
    public bool MouseOver { get; set; }
    public Vector3 Position { get { return gameObject.transform.position; } }

    //test stuff
    public int MoveDistance { get; set; }
    public Path Path { get; set; }
    public SelectorHalo SelectorHalo { get; set; }
    
    void Awake()
    {
        var iehManager = new PlayerIEH(this);
        Path = null;

        MoveDistance = 10;
        CanMove = true;

        var line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = true;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetColors(Color.white, Color.blue);
    }
    void Start ()
	{
	    
        transform.Translate(Random.Range(-2, 2), Random.Range(-2, 2),0);

	}
    private void Move(Vector3 startPos, Vector3 endPos)
    {
        if (!CanMove) return;

        gameObject.transform.position = Vector3.Lerp(startPos, endPos,  PlayerSpeed/100*Time.deltaTime);
    }
	void Update ()
	{
       
	}
    
    void OnMouseOver()
    {
        MouseOver = true;
        if (SelectorHalo == null) SelectorHalo = PrefabFactory.Instance.CreateSelectorHalo(this);
    }
    private void OnMouseExit()
    {
        MouseOver = false;
    }
}