using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LickerTickler : MonoBehaviour
{
    public Transform Player;
    public float range;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    private float fireCountdown = 0f;
    public Transform firePoint;

    bool inRange;

    public AudioSource aud;

    void Update()
    {
        if (inRange == true)
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        aud.Play();
    }
}
