using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LickerTicklerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject licker;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(licker, 0.7f);
    }

}
