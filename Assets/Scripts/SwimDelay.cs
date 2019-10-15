using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimDelay : MonoBehaviour
{
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<PlayerController>().canSwim = true;
    }

    public void startDelay()
    {
        StartCoroutine("Delay");
    }
}
