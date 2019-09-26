using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;
    public int enemyCount;
    public float enemySpawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnInterval);
            if (transform.childCount == 0)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Instantiate(enemy, transform);
                    float range = 10.0f;
                    Vector3 position = new Vector3();
                    position.x = Random.Range(-range, range);
                    position.y = Random.Range(0.0f, range);
                    position.z = Random.Range(-range, range);
                    enemy.transform.position = position;
                }
            }
            yield return null;
        }
    }
}
