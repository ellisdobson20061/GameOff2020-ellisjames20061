using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    public float speed = 13f;
    Rigidbody2D rb;
    public int damage;
    public GameObject shotBullet;
    public GameObject dirstSplat;

    public string enemyTag;


    private Transform target;
    private Enemy targetEnemy;

    void Start()
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

        rb = GetComponent<Rigidbody2D>();
        Vector2 moveDir = (nearestEnemy.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag == "spikes")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(shotBullet);
            }
        }

        if (hitInfo.gameObject.tag == "ground")
        {
            Instantiate(dirstSplat, transform.position, transform.rotation);
            Destroy(shotBullet);
        }
    }
}
