using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    private float currentSpeed = 3.0f;
    private float speed = 3.0f;
    private int gravity = -1;
    private int balloons = 2;
    private bool canMove = true;
    private GameObject carrying;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // reset velocity so diver doesn't fly away
        rb.velocity = new Vector2(0, gravity);
        
        // get keyboard input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // up
        if (inputY > 0 && canMove)
        {
            rb.position += new Vector2(0, 1);
            canMove = false;
        }

        // left
        if (inputX < 0)
        {
            rb.velocity = new Vector2(inputX, -0.5f) * currentSpeed;
        }
        
        // right
        if (inputX > 0)
        {
            rb.velocity = new Vector2(inputX, -0.5f) * currentSpeed;
        }

        // delay for swimming up
        if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
            canMove = true;
    }

    private void checkDead()
    {
        if (balloons <= 0)
        {
            // TODO die animation
            FindObjectOfType<GameManager>().GetComponent<GameManager>().setGameOver();
        }
    }

    // on touching gold, pick it up
    public void pickUp(GameObject gold)
    {
        if (carrying == null)
        {
            carrying = gold;
            // anim for picking up 
            // reduce speed based on gold value
            currentSpeed -= carrying.GetComponent<GoldValue>().getValue() * 0.2f;
        }
    }

    // after touching boat while carrying gold, destroy gold and add points to score
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Boat") && carrying != null)
        {
            // get value of gold
            int points = carrying.GetComponent<GoldValue>().getValue();
            // destroy object and remove reference from player
            Destroy(carrying);
            carrying = null;
            currentSpeed = speed;
            // send point info to game manager
            FindObjectOfType<GameManager>().GetComponent<GameManager>().addPoints(points);
        }
    }

    // take away balloons if touched by enemy
    public void addDamage()
    {
        balloons--;
        //TODO balloon popping anim
    }
}
