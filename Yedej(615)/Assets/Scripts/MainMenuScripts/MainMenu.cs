using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public AudioSource AudioSource;
    public float musicVolume = 1f;
    public GameObject tutorialPanel;
    public GameObject mainMenu;
    public TMP_Text helpText; 

    void Update()
    {
        if(AudioSource != null)
        {
        
        AudioSource.volume = musicVolume;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //gets the activeScene index and adds 1 to it and loads that scene.     
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BacToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1, LoadSceneMode.Single);
        PlayerScript.isChased = false;
        PlayerScript.line = 1;
        PlayerScript.score = 0;
        ItemGenerator.speed = 7;
        ItemGenerator.spawnTime = 1;
        LoopingBackground.backgroundSpeed = 7 / 9;
    }
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
    public void openHelpMenu()
    {
        if (!tutorialPanel.activeInHierarchy)
        {
            tutorialPanel.SetActive(true);
            helpText.text = "<-";
            mainMenu.SetActive(false);

        }
        else
        {
            helpText.text = "?";
            tutorialPanel.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    public void Awake()
    {
        tutorialPanel.SetActive(false);
    }
}
