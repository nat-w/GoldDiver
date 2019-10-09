using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // prefabs to pass to spawner
    public GameObject smallShark;
    public GameObject bigShark;
    public GameObject octopus;
    public GameObject smallGold;
    public GameObject bigGold;
    public GameObject bagGold;
    
    // reference to spawner script
    private Spawner spawner;
    // current level
    private static int level = 1;
    private static int score = 0;
    private bool gameOver = false;
    private List<GameObject> enemies = new List<GameObject>();
    private List<GameObject> golds = new List<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        // get spawner
        spawner = GetComponent<Spawner>();
            
    }

    private void Update()
    {
        if (!gameOver)
        {
            // spawn golds
            
            // spawn enemies
            
            // check level
        }
    }

    public int getScore()
    {
        return score;
    }

    public int getLevel()
    {
        return level;
    }

    public void addPoints(int points)
    {
        score += points;
    }

    public void setGameOver()
    {
        gameOver = true;
    }
        
        
    // enemy and pickup spawn methods    
    private void spawnSmallShark()
    {
        GameObject enemy = spawner.SpawnNew(smallShark, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);
        enemy.GetComponent<EnemyController>().setSpeed(1);
    }

    private void spawnBigShark()
    {
        GameObject enemy = spawner.SpawnNew(bigShark, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);
        enemy.GetComponent<EnemyController>().setSpeed(2);
    }

    private void spawnOctopus()
    {
        GameObject enemy = spawner.SpawnNew(octopus, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);
        enemy.GetComponent<EnemyController>().setSpeed(2);
    }

    private void spawnSmallGold()
    {
        GameObject gold = spawner.SpawnNew(smallGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold);

    }

    private void spawnBigGold()
    {
        GameObject gold = spawner.SpawnNew(bigGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold);
    }

    private void spawnBagGold()
    {
        GameObject gold = spawner.SpawnNew(bagGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold); 
    }
}
