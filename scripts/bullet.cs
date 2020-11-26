using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	public GameObject dirstSplat;
	public GameObject shotBullet;
	public AudioSource aud;
	public GameObject blood;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
		Destroy(this.gameObject, 0.7f);
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Destroy(shotBullet);
		}

		if(hitInfo.gameObject.tag == "ground")
		{
			Instantiate(dirstSplat, transform.position, transform.rotation);
			aud.Play();
			Destroy(shotBullet);
		}

		if (hitInfo.gameObject.tag == "spikes")
		{
			Instantiate(blood, transform.position, transform.rotation);
		}
	}

}