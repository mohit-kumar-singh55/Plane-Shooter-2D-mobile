using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] enemy;
    public float respawnTime = 3f;

    private void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemy.Length);
        float randomXPos = Random.Range(-2.5f, 2.5f);
        Instantiate(enemy[randomEnemy], new Vector2(randomXPos, transform.position.y), Quaternion.identity);
    }
}
