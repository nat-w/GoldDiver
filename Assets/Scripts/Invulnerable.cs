using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{ 
    public void makeInvulnerable()
    {
        StartCoroutine("Invulnerability");
    }

    IEnumerator Invulnerability()
    {
        GetComponent<PlayerController>().anim.SetBool("Invincible", true);
        Physics2D.IgnoreLayerCollision(8, 9, true);
        
        yield return new WaitForSeconds(2f);
        
        Physics2D.IgnoreLayerCollision(8, 9, false);
        GetComponent<PlayerController>().anim.SetBool("Invincible", false);
    }
}
