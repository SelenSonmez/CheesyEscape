using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public LoopingBackground background;
  
    // Update is called once per frame
    void Update()
    {
        int score = PlayerScript.score;
        float scoreMulitplier = (score * 10) / 100;
        Debug.Log("item speed" + ItemGenerator.speed);
        backgroundSpeed = (float)ItemGenerator.speed / 9;
        //Debug.Log("score "+score);

        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);      
    }
}
