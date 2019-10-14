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
    private static int numGolds = 3;
    private static int numSharks = 2;
    private static int numOctos = 1;
    private bool gameOver = false;
    private GameObject[] golds = new GameObject[numGolds];
    private GameObject[] sharks = new GameObject[numSharks];
    private GameObject[] octos = new GameObject[numOctos];
    
    void Awake()
    {
        // get spawner
        spawner = GetComponent<Spawner>();

        spawnEnemy(1);
    }

    private void Update()
    {
        if (!gameOver)
        {
            // spawn golds
            for (int i = 0; i < numGolds; i++)
            {
                if (golds[i] == null)
                    golds[i] = spawnGold(Random.Range(1, 3));
            }

            // spawn golds
            for (int i = 0; i < numSharks; i++)
            {
                if (sharks[i] == null)
                    sharks[i] = spawnEnemy(Random.Range(1, 2));
            }
            
            // spawn octo if level > 2
            if (level >= 2 && octos[0] == null)
            {
                octos[0] = spawnEnemy(3);
            }

            // increase level every 5 points earned
            if (score / 5 > level)
            {
                increaseLevel();
            }
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
    
    // spawn an enemy object in scene and return reference
    // 1 - small shark, 2 - big shark, 3 - octopus
    private GameObject spawnEnemy(int type)
    {
        GameObject enemy;
        switch (type)
        {
            case 1:
                enemy = spawner.spawnNew(smallShark, new Vector2(10, Random.Range(-3, 0)));
                return enemy;
            case 2:
                enemy = spawner.spawnNew(bigShark, new Vector2(10, Random.Range(-3, 0)));
                return enemy;
            case 3:
                enemy = spawner.spawnNew(octopus, new Vector2(10, Random.Range(-3, 0)));
                return enemy;
            default:
                return null;
        }
    }
    
    
    // spawn a gold object in scene and return reference
    // 1 - small gold, 2 - big gold, 3 - bag of gold
    private GameObject spawnGold(int type)
    {
        GameObject gold;
        switch (type)
        {
          case 1:
              gold = spawner.spawnNew(smallGold, new Vector2(Random.Range(-8, 8), -4));
              return gold;
          case 2:
              gold = spawner.spawnNew(bigGold, new Vector2(Random.Range(-8, 8), -4));
              return gold;
          case 3:
              gold = spawner.spawnNew(bagGold, new Vector2(Random.Range(-8, 8), -4));
              return gold;
          default:
              return null;
        }
    }
    
    // destroys all enemies and golds and increases level
    private void increaseLevel()
    {
        level++;
        foreach (GameObject gold in golds)
        {
            Destroy(gold);
        }
        
        foreach (GameObject shark in sharks)
        {
            Destroy(shark);
        }
        foreach (GameObject octo in octos)
        {
           Destroy(octo); 
        }
    }
}
