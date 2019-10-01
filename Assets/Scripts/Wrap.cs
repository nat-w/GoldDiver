using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move too far left, wrap right
        if (rb.position.x < -9.5)
        {
            rb.position = new Vector2(9, rb.position.y);
        }
        
        // move too far right, wrap left
        else if (rb.position.x > 9.5)
        {
            rb.position = new Vector2(-9, rb.position.y);

        }
        
    }
}
