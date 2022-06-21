using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandler : MonoBehaviour
{
    public Sprite[] powerUpSprites;
    public GameObject UIElementPrefab;
    public static PowerUpHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void displayPowerUp(int index, float duration)
    {
        var powerUpUIItem = Instantiate(UIElementPrefab, transform.position, transform.rotation, transform);
        powerUpUIItem.transform.GetChild(0).GetComponent<Image>().sprite = powerUpSprites[index];
        StartCoroutine(Duration(powerUpUIItem.transform.GetChild(1).GetComponent<Image>(), duration,powerUpUIItem));
        
    }
    IEnumerator Duration(Image radialImage,float duration, GameObject powerUpUIItem)
    {
        float speed = duration * 0.01f;
        while (radialImage.fillAmount > 0)
        {
            yield return new WaitForSeconds(speed);
            radialImage.fillAmount -= 0.01f;
        }
        Destroy(powerUpUIItem);
    }
}
