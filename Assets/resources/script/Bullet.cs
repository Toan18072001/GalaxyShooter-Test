using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (direction != null)
        //{
        //    transform.position += direction * speed * Time.deltaTime;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zone")|| collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
