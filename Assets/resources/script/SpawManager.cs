using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    public static SpawManager instance;
    [SerializeField] 
    private int coutEnemy = 12;
    private int curentEnemy = 0;
    [SerializeField]
    private GameObject enemyPrefab;
    public GameObject ParentEnemy;
    public Vector2 startPosition;
    public float spaceColum = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        //enemyPool.ObjectPrefab = Resources.Load<Enemy>("prefab/EnemyPrefab");
        StartCoroutine(SpawnEnemies());
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
   
    private void Awake()
    {
        instance = this;
    }

    IEnumerator SpawnEnemies()
    {
        if (curentEnemy >= coutEnemy)
        {
            GameManager.Instance.ischeckWin = true;
            StartCoroutine(EnemyManager.instance.CountDownStartEnemyMoveDown());
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameObject enemy = Instantiate(enemyPrefab, PathController.instance.paths[0].transform.position, Quaternion.identity);
            enemy.transform.parent = ParentEnemy.transform;
            enemy.tag = "Enemy";
            if (curentEnemy == 7 || curentEnemy == 11)
            {
                PathController.instance.startPositionRow = new Vector2(startPosition.x, PathController.instance.startPositionRow.y - spaceColum);
            }
            curentEnemy++;
            StartCoroutine(SpawnEnemies());
        }
    }
}
