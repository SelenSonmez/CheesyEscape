using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour
{
    private static ItemGenerator _instance;

    public GameObject apple;
    public GameObject cheese;
    public GameObject obstacle;
    public GameObject cheesePowerUp;
    public GameObject reversePowerUp;
    public GameObject slowPowerUp;
    public GameObject giftItem;
    public GameObject magnetPowerUp;
    public static float speed = 7;
    public bool isSpawn = false;
    public static float spawnTime = 1;
    public List<GameObject> obstacles = new List<GameObject>();
    public GameObject player;
    public GameObject GameOverPanel;
    public Text score;
    public Text highscore;
    public Text playerScore;

    public List<GameObject> getObstacles()
    {
        return obstacles;
    }
    public GameObject getCheese()
    {
        return cheese;
    }

    public Text getPlayerScore()
    {
        return playerScore;
    }
    public Text getScore()
    {
        return score;
    }
    public Text getHighScore()
    {
        return highscore;
    }

    public GameObject getPanel()
    {
        return GameOverPanel;
    }
    public static ItemGenerator instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Item Generator is null");
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
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
        PlayerScript.player = Instantiate(player, new Vector3(-4.71f, -2.36f), transform.rotation);
        isSpawn = true;
        StartCoroutine(generateItem());
    }
    IEnumerator generateItem()
    {

        while (isSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            int probability = Random.Range(0, 100);
            if (probability <= 10)
            {
                GameObject cheeseIns = Instantiate(cheese, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            }
            else if (probability <= 20)
            {
                GameObject appleIns = Instantiate(apple, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            }
            else if (probability <= 25)
            {
                int i = Random.Range(0, 3);
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(8, 3 * i, 0), transform.rotation);
                Instantiate(slowPowerUp, transform.position + new Vector3(4, 3 * i, 0), transform.rotation);
                GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * i, 0), transform.rotation);
                obstacles.Add(obstacleIns);
                obstacles.Add(obstacleInsTwo);
                if (i == 1)
                {
                    int j = Random.Range(0, 3);
                    if (j == 0)
                    {   
                        GameObject obj = Instantiate(obstacle, transform.position + new Vector3(4, 6, 0), transform.rotation);
                        obstacles.Add(obj);
                    }
                    if (j == 1)
                    {
                        GameObject obj = Instantiate(obstacle, transform.position + new Vector3(4, 0, 0), transform.rotation);
                        obstacles.Add(obj);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
            else if (probability <= 28)
            {
                int i = Random.Range(0, 3);
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(8, 3 * i, 0), transform.rotation);
                Instantiate(cheesePowerUp, transform.position + new Vector3(4, 3 * i, 0), transform.rotation);
                GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * i, 0), transform.rotation);
                if (i == 1)
                {
                    int j = Random.Range(0, 3);
                    if (j == 0)
                    {   
                        Instantiate(obstacle, transform.position + new Vector3(4, 6, 0), transform.rotation);

                    }
                    if (j == 1)
                    {   
                        Instantiate(obstacle, transform.position + new Vector3(4, 0, 0), transform.rotation);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
            else if (probability <= 31)
            {
                int i = Random.Range(0, 3);
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(8, 3 * i, 0), transform.rotation);
                Instantiate(giftItem, transform.position + new Vector3(4, 3 * i, 0), transform.rotation);
                GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * i, 0), transform.rotation);
                obstacles.Add(obstacleIns);
                obstacles.Add(obstacleInsTwo);
                if (i == 1)
                {
                    int j = Random.Range(0, 3);
                    if (j == 0)
                    {
                        GameObject obs = Instantiate(obstacle, transform.position + new Vector3(4, 6, 0), transform.rotation);
                        obstacles.Add(obs);
                    }
                    if (j == 1)
                    {
                        GameObject obs = Instantiate(obstacle, transform.position + new Vector3(4, 0, 0), transform.rotation);
                        obstacles.Add(obs);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
            else if (probability <= 35)
            {
                Instantiate(reversePowerUp, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
            }
            else if (probability <= 40)
            {
                int i = Random.Range(0, 3);
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(8, 3 * i, 0), transform.rotation);
                Instantiate(magnetPowerUp, transform.position + new Vector3(4, 3 * i, 0), transform.rotation);
                GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * i, 0), transform.rotation);
                obstacles.Add(obstacleIns);
                obstacles.Add(obstacleInsTwo);
                if (i == 1)
                {
                    int j = Random.Range(0, 3);
                    if (j == 0)
                    {
                        GameObject obs = Instantiate(obstacle, transform.position + new Vector3(4, 6, 0), transform.rotation);
                        obstacles.Add(obs);

                    }
                    if (j == 1)
                    {
                        GameObject obs = Instantiate(obstacle, transform.position + new Vector3(4, 0, 0), transform.rotation);
                        obstacles.Add(obs);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
            else
            {
                int rand = Random.Range(0, 3);
                int secondRand = 0;
                while (rand == secondRand)
                {
                    secondRand = Random.Range(0, 3);
                }
                if (Random.Range(0, 2) == 1)
                {
                    GameObject obstacleInsTwo = Instantiate(obstacle, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
                    obstacles.Add(obstacleInsTwo);
                }
                GameObject obstacleIns = Instantiate(obstacle, transform.position + new Vector3(0, 3 * Random.Range(0, 3), 0), transform.rotation);
                obstacles.Add(obstacleIns);
            }

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        PlayerScript.isChased = false;
        PlayerScript.line = 1;
        PlayerScript.score = 0;
        speed = 7;
        spawnTime = 1;
        LoopingBackground.backgroundSpeed = 7 / 9;

    }
}
