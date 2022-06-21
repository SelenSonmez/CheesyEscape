using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip eatCheeseSound, eatAppleSound, gameOverSound,obstacleHit,chasePlayer,inGame, mainMenu, giftPicked,slowPicked,reversePicked,magnetPicked,wandPicked;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        eatAppleSound = Resources.Load<AudioClip>("eatApple");
        eatCheeseSound = Resources.Load<AudioClip>("eatCheese");
        obstacleHit = Resources.Load<AudioClip>("obstacleHit");
        chasePlayer = Resources.Load<AudioClip>("chase");
        mainMenu = Resources.Load<AudioClip>("mainMenu");
        inGame = Resources.Load<AudioClip>("inGame");
        giftPicked = Resources.Load<AudioClip>("giftPicked");
        slowPicked = Resources.Load<AudioClip>("slowPicked");
        reversePicked = Resources.Load<AudioClip>("reversePicked");
        magnetPicked = Resources.Load<AudioClip>("magnetPicked");
        wandPicked = Resources.Load<AudioClip>("wandPicked");

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = inGame;
        audioSrc.loop = true;
        audioSrc.Play();
    }


    public static void PlaySound(string clip)
    {
        //audioSrc.volume = 1;
       // audioSrc.Play();
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
            case "giftPicked":
                audioSrc.PlayOneShot(giftPicked);
                break;
            case "slowPicked":
                audioSrc.PlayOneShot(slowPicked);
                break;
            case "reversePicked":
                audioSrc.PlayOneShot(reversePicked);
                break;
            case "magnetPicked":
                audioSrc.PlayOneShot(magnetPicked);
                break;
            case "wandPicked":
                audioSrc.PlayOneShot(wandPicked);
                break;


        }
    }
}
