using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool ischeckWin = false;
    public bool ischeckThreeBullet = false; //ttt
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ischeckWin)
        {
            CheckWin();
        }
    }
    public void CheckWin()
    {
        if (SpawManager.instance.ParentEnemy.transform.childCount <= 0)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    public void Gamelose()
    {
        SceneManager.LoadScene("GameLose");
    }
}
