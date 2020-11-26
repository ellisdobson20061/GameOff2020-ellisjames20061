using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public GameObject Player;
    public ParticleSystem Death;
    public AudioSource aud;

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Player")
        {
            Destroy(Player);
            SceneManager.LoadScene(5);
        }
    }
}
