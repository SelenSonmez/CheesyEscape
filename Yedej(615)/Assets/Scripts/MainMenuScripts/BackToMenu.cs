using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BacToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
        PlayerScript.isChased = false;
        PlayerScript.line = 1;
        PlayerScript.score = 0;
        ItemGenerator.speed = 7;
        ItemGenerator.spawnTime = 1;
        LoopingBackground.backgroundSpeed = 7 / 9;
    }


}
