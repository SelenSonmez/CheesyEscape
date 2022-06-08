using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //gets the activeScene index and adds 1 to it and loads that scene.
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
