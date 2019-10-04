using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnNew(GameObject prefab, Vector2 pos)
    {
        GameObject obj = (GameObject)Instantiate(prefab);
        obj.transform.position = pos;

        return obj;
    }
}
