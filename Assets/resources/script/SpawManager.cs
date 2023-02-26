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
    public Vector2 startPosition = new Vector2 (-2.55f, 4.37f);
    public float spaceColum = 1.7f;
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
            StartCoroutine(EnemyManager.instance.CountDownStartEnemyMoveDown());
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameObject enemy = Instantiate(enemyPrefab, PathController.instance.paths[0].transform.position, Quaternion.identity);
            enemy.transform.parent = ParentEnemy.transform;
            if (curentEnemy == 7 || curentEnemy == 11)
            {
                PathController.instance.startPosition = new Vector2(-2.55f, PathController.instance.startPosition.y - spaceColum);
            }
            curentEnemy++;
            StartCoroutine(SpawnEnemies());
        }
    }
}
