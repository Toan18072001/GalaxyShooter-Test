using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public static PathController instance;
    public List<GameObject> paths = new List<GameObject>();
    public Vector2 startPositionRow = new Vector2(-2f, 4.37f);
    public bool isMoveDown;
    public List<Vector2> posEnmenys= new List<Vector2>();
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

}
