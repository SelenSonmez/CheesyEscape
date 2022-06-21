using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoopingBackground : MonoBehaviour
{
    public static float backgroundSpeed;
    public Renderer backgroundRenderer;
    public LoopingBackground background;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public Camera camera;
    public Text gameScore;
    public Text gameHighScore;
    public bool entered;            //bool value to prevent the background change when apple(-1) is picked.
    // Update is called once per frame
    void Update()
    {
        int score = PlayerScript.score;
        float scoreMulitplier = (score * 10) / 100;
        backgroundSpeed = (float)ItemGenerator.speed / 9;
        //Debug.Log("score "+score);
        if (PlayerScript.score > 10 && !(entered))
        {
            plane1.SetActive(false);
            plane2.SetActive(true);
            camera.backgroundColor = Color.yellow;
        }
        if (PlayerScript.score > 20 || entered)
        {
            entered = true;
            plane2.SetActive(false);
            plane3.SetActive(true);
            Color gray = new Color(220, 223, 227);
            camera.backgroundColor = gray;
            gameScore.color = Color.black;
            gameHighScore.color = Color.black;
        }

        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);      
    }
}
