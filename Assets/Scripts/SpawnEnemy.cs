using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject SpawnNewEnemy(GameObject enemyPrefab)
    {
        Vector2 pos = new Vector2(10, Random.Range(-3, 0));
        GameObject enemy = (GameObject)Instantiate(enemyPrefab);
        enemy.transform.position = pos;

        return enemy;
    }
}
