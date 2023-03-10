using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    //PathController pathController;
    public float spaceEnemy;
    public bool isFirstMove = false, isSecondMove = true, isMoveDown=false,inCheckEndPoint=false;
    //public Vector2 curentPosion;

    int coutFirstMove = 0;
    float endPointDown = -4.16f;
    int index;
    int curentIndexPath;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       // Vector2 temp = transform.position;
        if (!isFirstMove)
        {
            FistMoveEnemy();
        }else if(!isSecondMove)
        {
            SecondMovePos();
        }else if (isMoveDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, endPointDown), speed * Time.deltaTime);
            if(transform.position.y == endPointDown)
            {
                isMoveDown= false;
                inCheckEndPoint = true;
            }
        }
        
        if(!isMoveDown&&inCheckEndPoint)
        {
            if(index < 4)
            {
                Debug.Log("enemy index1: " + index);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, SpawManager.instance.startPosition.y), speed * Time.deltaTime);
            }else if(index>= 4 && index < 8)
            {
                Debug.Log("enemy index2: " + index);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, SpawManager.instance.startPosition.y - spaceEnemy), speed * Time.deltaTime);
            }
            else
            {
                Debug.Log("enemy index3: " + index);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, SpawManager.instance.startPosition.y - (spaceEnemy*2)), speed * Time.deltaTime);
            }
        }
    }
    void FistMoveEnemy()
    {
        int nextPath = curentIndexPath + 1;
        if (nextPath > PathController.instance.paths.Count - 1)
        {
            nextPath = 0;
        }
        if (!isFirstMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, PathController.instance.paths[nextPath].transform.position, speed * Time.deltaTime);

            if (transform.position == PathController.instance.paths[nextPath].transform.position)
            {
                curentIndexPath = nextPath;
                coutFirstMove++;
            }
        }
        if(coutFirstMove > 5)
        {
            isFirstMove = true;
            isSecondMove = false;
        }
        
    }
    private void SecondMovePos()
    {
        Debug.Log("SecondMovePos");
        Vector2 temp = transform.position;
        if (temp != PathController.instance.startPositionRow)
        {
            transform.position = Vector2.MoveTowards(transform.position, PathController.instance.startPositionRow, speed * Time.deltaTime);
        }
        else
        {
            isSecondMove = true;
            PathController.instance.startPositionRow = new Vector2(PathController.instance.startPositionRow.x + spaceEnemy, PathController.instance.startPositionRow.y);
        }
    }

   
    public void setIndexEnemy(int _index)
    {
        index= _index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Gamelose();
        }
    }
}
