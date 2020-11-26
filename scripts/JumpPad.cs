using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce;
    public AudioSource jumpPadSound;
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Player = col.gameObject;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        jumpPadSound.Play();
        rb.AddForce(Vector2.up * jumpForce);
    }
}
