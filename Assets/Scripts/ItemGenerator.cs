using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private static ItemGenerator _instance;

    public GameObject apple;
    public GameObject cheese;
    public GameObject obstacle;
    public static int speed = 7;
    public bool isSpawn = false;
    public static float spawnTime = 1;

    public static ItemGenerator instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Item Generator is null");
            }
            return _instance;
        }
    }
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isSpawn = true;
        StartCoroutine(generateItem());
    }
    IEnumerator generateItem(){
        
        while (isSpawn) {
            yield return new WaitForSeconds(spawnTime);
            int probability = Random.Range(0, 10);
            if (probability == 0)
            {
                Debug.Log("0");
                GameObject cheeseIns = Instantiate(cheese, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            }
            else if (probability == 1)
            {
                Debug.Log("1");
                GameObject appleIns = Instantiate(apple, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            }
            else
            {
                Debug.Log("obtacle");
                int rand = Random.Range(0, 3);
                int secondRand = 0;
                while (rand == secondRand)
                {
                    secondRand = Random.Range(0, 3);
                }                  

                if(Random.Range(0,2) == 1)
                {
                    GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
                }
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);           
            }    
            
        }      
    }
}
