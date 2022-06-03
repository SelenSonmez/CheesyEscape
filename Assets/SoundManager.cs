using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip eatCheeseSound, eatAppleSound, gameOverSound,obstacleHit;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        eatAppleSound = Resources.Load<AudioClip>("eatApple");
        eatCheeseSound = Resources.Load<AudioClip>("eatCheese");
        obstacleHit = Resources.Load<AudioClip>("obstacleHit");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        audioSrc.volume = 1;
        audioSrc.Play();
        switch (clip)
        {
            case "apple":
                audioSrc.PlayOneShot(eatAppleSound);
                break;
            case "cheese":
                audioSrc.PlayOneShot(eatCheeseSound);
                break;
            case "obstacle":
                audioSrc.PlayOneShot(obstacleHit);
                break;
        }
    }
}
