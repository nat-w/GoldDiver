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
            foreach (GameObject gold in golds)
            {
                if(gold == null)
                    s
            }
            
            // spawn enemies
            
            // check level
            if ((int) (score / 5) > level)
            {
                level++;
                
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
              gold = spawner.spawnNew(bigGold, new Vector2(Random.Range(-8, 8), -4));
              return gold;
          default:
              return null;
        }
    }
}
