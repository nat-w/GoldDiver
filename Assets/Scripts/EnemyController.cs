using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed = 5;
    public bool octo = false;
    public int dir = 1;
    private AudioSource biteSound;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        biteSound = GetComponent<AudioSource>();
        
        // flip the sprite according to direction
        transform.localScale = new Vector3(transform.localScale.x * dir * -1, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    private void move()
    {
        if (octo)
        {
            rb.velocity = new Vector2(speed * dir, 0);
            rb.position = new Vector2(rb.position.x, Mathf.Sin(Time.time));
        }
        else
        {
            rb.velocity = new Vector2(speed * dir, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            biteSound.Play();
            other.GetComponent<PlayerController>().addDamage();
        }
    }
}
