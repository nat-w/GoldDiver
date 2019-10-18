using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject boostPrefab;

    // reference to spawner script
    private Spawner spawner;
    
    // current level
    private int level = 1;
    private int score = 0;
    private static int numGolds = 3;
    private static int numSharks = 2;
    private static int numOctos = 1;
    private static int numBoosts = 1;
    private bool gameOver = false;
    private bool gameEnded = false;
    private GameObject[] golds = new GameObject[numGolds];
    private GameObject[] sharks = new GameObject[numSharks];
    private GameObject[] octos = new GameObject[numOctos];
    private GameObject[] boosts = new GameObject[numBoosts];
    private AudioSource loseSound;
    
    void Awake()
    {
        // get spawner
        spawner = GetComponent<Spawner>();
        loseSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!gameOver)
        {
            // spawn golds
            for (int i = 0; i < numGolds; i++)
            {
                if (golds[i] == null)
                    golds[i] = spawnGold(Random.Range(1, 4));
            }

            // spawn golds
            for (int i = 0; i < numSharks; i++)
            {
                if (sharks[i] == null)
                    sharks[i] = spawnEnemy(Random.Range(1, 3));
            }
            
            // spawn octo if level > 2
            if (level >= 2 && octos[0] == null)
            {
                octos[0] = spawnEnemy(3);
            }
            
            // randomly spawn a boost
            if (Random.Range(0, 900) == 0 && boosts[0] == null)
            {
                boosts[0] = spawnBoost();
            }

            // increase level every 5 points earned
            if (score / 5 > (level - 1))
            {
                destroyAll();
                level++;
            }
        }
        else if (!gameEnded)
        {
            endGame();
            gameEnded = true;
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

    // method called from outside to signal end of game
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
                enemy = spawner.spawnNew(smallShark, new Vector2(11, Random.Range(-3, 1)));
                enemy.GetComponent<EnemyController>().setSpeed(Random.Range(1, 4));
                enemy.GetComponent<EnemyController>().dir = Random.Range(0, 2) == 0 ? -1 : 1;
                return enemy;
            case 2:
                enemy = spawner.spawnNew(bigShark, new Vector2(11, Random.Range(-3, 1)));
                enemy.GetComponent<EnemyController>().setSpeed(Random.Range(2, 4));
                enemy.GetComponent<EnemyController>().dir = Random.Range(0, 2) == 0 ? -1 : 1;

                return enemy;
            case 3:
                enemy = spawner.spawnNew(octopus, new Vector2(11, Random.Range(-3, 1)));
                enemy.GetComponent<EnemyController>().dir = Random.Range(0, 2) == 0 ? -1 : 1;

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
              gold = spawner.spawnNew(smallGold, new Vector2(Random.Range(-8, 9), -4));
              return gold;
          case 2:
              gold = spawner.spawnNew(bigGold, new Vector2(Random.Range(-8, 9), -4));
              return gold;
          case 3:
              gold = spawner.spawnNew(bagGold, new Vector2(Random.Range(-8, 9), -4));
              return gold;
          default:
              return null;
        }
    }

    private GameObject spawnBoost()
    {
        GameObject boost = spawner.spawnNew(boostPrefab, new Vector2(Random.Range(-6, 7), Random.Range(-3, 2)));
        return boost;
    }
    
    // destroys all enemies and golds and increases level
    private void destroyAll()
    {
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

        foreach (GameObject boost in boosts)
        {
            Destroy(boost);
        }
    }

    // small delay before stopping game and showing game over screen
    private void endGame()
    {
        loseSound.Play();
        GameObject.Find("GameOverCanvas").GetComponent<Canvas>().enabled = true;
    }

    // restarts game by reloading main scene
    public void restartGame()
    {
        destroyAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
