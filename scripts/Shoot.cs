using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	public AudioSource aud;

	public GameObject MuzzleFlash;
	[Range(0, 5)]
	public int FramToFlash = 1;
	bool flashing = false;

	public Rigidbody2D rb;

	void Start()
	{
		MuzzleFlash.SetActive(false);
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			hoot();
			aud.Play();
			if (!flashing)
			{
				StartCoroutine(Flashtime());
			}
		}
	}

	public void hoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	
	}

	IEnumerator Flashtime()
	{
		MuzzleFlash.SetActive(true);
		var frameflash = 0;
		flashing = true;
		while (frameflash <= FramToFlash)
		{
			frameflash++;
			yield return null;
		}
		MuzzleFlash.SetActive(false);
		flashing = false;
	}
}
