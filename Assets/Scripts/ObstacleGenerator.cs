using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject apple;
    public GameObject cheese;
    public GameObject obstacle;
    public int speed = 7;
    void Awake()
    {
        generateObstacle();
    }
    public void generateObstacle(){

        int probability = Random.Range(0, 10);
        if (probability == 0)
        {  
            GameObject cheeseIns = Instantiate(cheese, transform.position + new Vector3(0, 3 * Random.Range(0, 3),0), transform.rotation);
            cheeseIns.GetComponent<CheeseScript>().obstacleGenerator = this;
            return;
        }
        if (probability == 1)
        {
            GameObject appleIns = Instantiate(apple, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            appleIns.GetComponent<AppleScript>().obstacleGenerator = this;
            return;
        }
        GameObject obstacleIns = Instantiate(obstacle,transform.position + new Vector3(0,3*Random.Range(0, 3),0),transform.rotation);
       obstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
