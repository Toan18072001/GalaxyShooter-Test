using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    //public int moveDown = 3;
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
        //Debug.Log("Child count: " + transform.childCount);
        //if (transform.childCount == 12 && transform.GetChild(11).GetComponent<Enemy>().isSecondMove != true&& transform.GetChild(11).GetComponent<Enemy>().isFirstMove == true)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - moveDown), 5 * Time.deltaTime);
        //    Debug.Log("move: "+"Child count: "+transform.childCount);
        //}
    }

    public IEnumerator CountDownStartEnemyMoveDown()
    {
        yield return new WaitForSeconds(3f);
       StartCoroutine(RandomeMoveDownEnemy());
    }

    IEnumerator RandomeMoveDownEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4));
        int rand = Random.Range(0, 12);
        transform.GetChild(rand).GetComponent<Enemy>().isMoveDown= true;
        transform.GetChild(rand).GetComponent<Enemy>().setIndexEnemy(rand);
        Debug.Log("Index: " + rand);
        StartCoroutine(RandomeMoveDownEnemy());
    }
}
