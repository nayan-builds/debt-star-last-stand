using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public void SpawnEnemy()
    {
        Vector3 spawnOffset = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
        Instantiate(enemyPrefab, transform.position + spawnOffset, transform.rotation);
    }
}
