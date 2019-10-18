using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sparkleParticle;
    public GameObject bloodParticle;
    private Rigidbody2D rb;
    public Animator anim;
    private AudioSource goldSound;
    private float currentSpeed = 3.0f;
    private bool canSwim = true;
    private bool isDead = false;
    private float speed = 3.0f;
    private float gravity = -0.5f;
    private int balloons = 2;
    private BalloonController balloonController;
    private GameObject carrying;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        goldSound = GetComponent<AudioSource>();
        balloonController = FindObjectOfType<BalloonController>();
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
        if (inputY > 0 && canSwim && !isDead)
        {
            anim.SetTrigger("SwimUp");
            rb.velocity = new Vector2(0, 10) * currentSpeed;
            canSwim = false;
            StartCoroutine("SwimDelay");
        }
        
        // down
        if (inputY < 0 && !isDead)
        {
            rb.velocity = new Vector2(0, -1) * currentSpeed;
        }

        // left
        if (inputX < 0 && !isDead)
        {
            rb.velocity = new Vector2(inputX, gravity * 0.5f) * currentSpeed;
        }
        
        // right
        if (inputX > 0 && !isDead)
        {
            rb.velocity = new Vector2(inputX, gravity * 0.5f) * currentSpeed;
        }
    }

    private void dead()
    {
        anim.SetBool("Dead", true);
        rb.velocity = new Vector2(0, -10f);
        isDead = true;
        FindObjectOfType<GameManager>().GetComponent<GameManager>().setGameOver();
    }

    // on touching gold, pick it up
    public void pickUp(GameObject gold)
    {
        if (carrying == null)
        {
            carrying = gold;
            
            // create and destroy particle effect
            GameObject sparkle = Instantiate(sparkleParticle, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            sparkle.GetComponent<ParticleSystem>().Play();
            Destroy(sparkle, 3);
            
            // play sound effect
            goldSound.Play();
            
            gold.GetComponent<GoldController>().setCarry(true);
            // reduce speed based on gold value
            //currentSpeed -= carrying.GetComponent<GoldController>().getValue() * 0.2f;
        }
    }

    // after touching boat while carrying gold, destroy gold and add points to score
    public void dropOff()
    {
        if (carrying != null)
        {
            // get value of gold
            int points = carrying.GetComponent<GoldController>().getValue();
            
            // create and destroy particle effect
            GameObject sparkle = Instantiate(sparkleParticle, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            sparkle.GetComponent<ParticleSystem>().Play();
            Destroy(sparkle, 3);
            
            // play sound effect
            goldSound.Play();
            
            // destroy object and remove reference from player
            Destroy(carrying);
            carrying = null;
            // send point info to game manager
            FindObjectOfType<GameManager>().GetComponent<GameManager>().addPoints(points);
        }
    }

    // take away balloons if touched by enemy
    public void addDamage()
    {
        if (balloons <= 0)
        {
            dead();
            return;
        }
        
        // set animation
        anim.SetTrigger("Hurt");
        
        // create and destroy particle effect
        GameObject blood = Instantiate(bloodParticle, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        blood.GetComponent<ParticleSystem>().Play();
        Destroy(blood, 3);
        
        balloons--;
        balloonController.balloonPop(balloons);
        StartCoroutine("Invulnerability");
    }

    public void changeSpeed(int newSpeed, bool reset = false)
    {
        if (reset)
        {
            currentSpeed = speed;
        }

        else
        {
            // create and destroy particle effect
            GameObject sparkle = Instantiate(sparkleParticle, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            sparkle.GetComponent<ParticleSystem>().Play();
            Destroy(sparkle, 3);
            
            currentSpeed = newSpeed;
        }
    }
    
    IEnumerator Invulnerability()
    {
        anim.SetBool("Invincible", true);
        Physics2D.IgnoreLayerCollision(8, 9, true);
        
        yield return new WaitForSeconds(2f);
        
        anim.SetBool("Invincible", false);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    
    IEnumerator SwimDelay()
    {
        yield return new WaitForSeconds(0.15f);
        canSwim = true;
    }
}
