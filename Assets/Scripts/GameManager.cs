using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    private List<GameObject> enemies = new List<GameObject>();
    private List<GameObject> golds = new List<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        // get spawner
        spawner = GetComponent<Spawner>();
        
        
        
        
    }

    public int getScore()
    {
        return score;
    }

    public int getLevel()
    {
        return level;
    }

    private void spawnSmallShark()
    {
        GameObject enemy = spawner.spawnNew(smallShark, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);
    }

    private void spawnBigShark()
    {
        GameObject enemy = spawner.spawnNew(bigShark, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);

    }

    private void spawnOctopus()
    {
        GameObject enemy = spawner.spawnNew(octopus, new Vector2(10, Random.Range(-3, 0)));
        enemies.Add(enemy);

    }

    private void spawnSmallGold()
    {
        GameObject gold = spawner.spawnNew(smallGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold);

    }

    private void spawnBigGold()
    {
        GameObject gold = spawner.spawnNew(bigGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold);
    }

    private void spawnBagGold()
    {
        GameObject gold = spawner.spawnNew(bagGold, new Vector2(Random.Range(-8, 8), -4));
        golds.Add(gold); 
    }
}
