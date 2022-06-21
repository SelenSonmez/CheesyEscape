using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScore;

    void awake()
    {
        scoreTxt.text = "Score: " + PlayerScript.score;
        highScore.text = "Highscore: " + PlayerScript.highscore;
    }
}
