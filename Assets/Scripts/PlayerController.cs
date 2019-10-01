using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public int speed = 3;
    private int gravity = -2;

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
        rb.velocity = new Vector2(0,gravity);
        
        // get keyboard input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // TODO: add delay for swimming up
        // up
        if (inputY > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, inputY) * speed;
        }

        // left
        if (inputX < 0)
        {
            rb.velocity = new Vector2(inputX, -0.5f) * speed;
        }
        
        // right
        if (inputX > 0)
        {
            rb.velocity = new Vector2(inputX, -0.5f) * speed;
        }
    }
}
