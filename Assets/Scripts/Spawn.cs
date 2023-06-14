using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnTime;
    float curspawnTime;
    [SerializeField] bool isSpawn;

    GameObject enemy;
    void Start()
    {
        curspawnTime = spawnTime;
    }
    private void Update()
    {
        curspawnTime-=Time.deltaTime;
        if(curspawnTime < 0)
        {
            enemy = PoolManager.instance.EnemyGet(Random.Range(0, 9));
            enemy.transform.position = spawnPoints[Random.Range(0, 4)].position;

            curspawnTime = spawnTime;
        }
    }
}