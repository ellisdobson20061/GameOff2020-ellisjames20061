using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioSource aud;

    BoxCollider2D box;
   
   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke ("DropPlatform", 0.5f);
            Destroy(gameObject, 3f);
		}

        if(col.gameObject.tag == "spikes")
        {
            box.isTrigger = true;
        }
    }

    void DropPlatform()
    {
       rb.isKinematic = false;
        aud.Play();
    }
}
