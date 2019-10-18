using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    public int speed = 8;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().changeSpeed(speed);
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine("BoostTime");
        }
    }

    private void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().changeSpeed(0, true);
    }

    IEnumerator BoostTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
