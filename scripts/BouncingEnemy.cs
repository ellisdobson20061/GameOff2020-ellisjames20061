using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : MonoBehaviour
{
    Rigidbody2D rb;

    private float jumpForce;

    public GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jumpForce = 11;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ground")
        {
            rb.velocity = new Vector2(0, 0);

          

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
    }
}
