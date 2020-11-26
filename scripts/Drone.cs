using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 35f;
    public Transform Player;

    public float lineOfSite = 1000;

    float stop = 1f;
    float speedup = 16;
    public float shootingRange;

    public string enemyTag;

    private Transform target;
    private Enemy targetEnemy;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public Transform firePoint;

    public AudioSource aud;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= shootingRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
        Debug.Log(nearestEnemy);
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
        }

        if(distanceFromPlayer < stop)
        {
            speed = 0;
        }


        if(speedup < distanceFromPlayer)
        {
            speed = 23f;
        }


        if (distanceFromPlayer > stop)
        {
            speed = 5.09f;
        }

        if (target == null)
        {
            DontShoot();
        }

        if (target == true)
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletPrefab, 0.5f);
    }

    void DontShoot()
    {

    }

    public void OnDrawGizmosEnter2D()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.color = Color.red;

    }
}
