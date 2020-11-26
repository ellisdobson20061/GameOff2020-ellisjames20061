using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public string creditsName;
    public AudioSource aud;
    public string menuName;


    void Start()
    {
    }
    public void SwitchToCredits()
    {
        SceneManager.LoadScene(creditsName);
        aud.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuName);
        aud.Play();
    }
}
