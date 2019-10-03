using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject smallShark;
    public GameObject bigShark;
    public GameObject octopus;
    
    private SpawnEnemy enemyScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemyScript = GetComponent<SpawnEnemy>();
        
        GameObject enemy = enemyScript.SpawnNewEnemy(smallShark);
    }
}
