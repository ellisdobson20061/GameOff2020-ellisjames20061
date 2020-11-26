using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BetterPlayerMovement : MonoBehaviour
{
    public float Speed;
    public Vector2 JumpForce;
    public bool canJump;

    bool isGrounded = false;
    bool isDashing;
    private bool facing = true;

    private float horizontal;

    public Animator anim;

    Rigidbody2D rb;
    float movX;

    public AudioSource aud;
    public AudioSource deathSound;

    public GameObject standard;
    public GameObject gameOver;

    public GameObject death;
    public GameObject Player;

    public GameObject dustEffect;
    public GameObject dustSpawnPos;

    public GameObject redPanel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        standard.SetActive(true);
        gameOver.SetActive(false);
        Player.SetActive(true);
        redPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movX * Speed, rb.velocity.y);
      
        if(canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    jump();
                    Instantiate(dustEffect, dustSpawnPos.transform.position, Quaternion.identity);
                }
            }
        }

        if (movX > 0 && !facing)
        {
            Flip();
        }
        else if (movX < 0 && facing)
        {
            Flip();
        }

        if(movX == 0)
        {
            anim.SetBool("Walk", false);
        }

        if (movX != 0)
        {
            anim.SetBool("Walk", true);
        }

        if(rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
        }

        if (rb.velocity.y != 0)
        {
            anim.SetBool("Jump", true);
        }

    }

    void jump()
    {
        rb.AddForce(JumpForce, ForceMode2D.Impulse);
        aud.Play();
        isGrounded = false;
    }

    private void Flip()
    {
        facing = !facing;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            Instantiate(dustEffect, dustSpawnPos.transform.position, Quaternion.identity);
        }
            
        if (collision.gameObject.tag == "spikes")
        {
            YouLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "turn red")
        {
            redPanel.SetActive(true);
        }
    }

    public void YouLose()
    {
        standard.SetActive(false);
        gameOver.SetActive(true);
        deathSound.Play();
        Instantiate(death, transform.position, transform.rotation);
        Player.SetActive(false);
    }
}
