using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject cat;
    public GameObject catIns;
    public GameObject cheese;
    public static int line;
    Rigidbody2D RB;
    public Text text;
    public static int score;
    public static bool isChased;
    public Text highscoreTxt;
    public static float highscore;
    public GameObject gameOverPanel;
    public static GameObject player;
    public bool isAnimated;
    public Text playerScore;
    public static bool isReversed;
    public static bool isMagnetActive;
    private List<string> magnets;
    private List<string> reverses;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("cheese"))
        {

            SoundManager.PlaySound("cheese");
            Destroy(other.gameObject);
            score++;
            if (score > PlayerPrefs.GetFloat("highscore"))
            {
                highscore = score;
                highscoreTxt.text = "Highscore: " + highscore;
                PlayerPrefs.SetFloat("highscore", highscore);

            }
            text.text = "Score: " + score;
            ItemGenerator.speed += 0.5f;
            if (ItemGenerator.spawnTime > 0.3f)
            {
                ItemGenerator.spawnTime -= 0.025f;

            }
        }
        if (other.gameObject.CompareTag("apple"))
        {
            SoundManager.PlaySound("apple");
            Destroy(other.gameObject);
            score--;
            text.text = "Score: " + score;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            
            if (!isChased)
            {
                isChased = true;
                catIns = Instantiate(cat, transform.position - new Vector3(3, 0.25f, 0), transform.rotation);
                StartCoroutine(wait());
                StartCoroutine(animationWait());
            }
            else
            {
                if (isAnimated) return;
                playerScore.text = "Score: " + score;
                gameOverPanel.SetActive(true);
                Destroy(player);
                if (score > PlayerPrefs.GetFloat("highscore"))
                {
                    PlayerPrefs.SetFloat("highscore", score);
                }

                PlayerPrefs.Save();
                highscore = PlayerPrefs.GetFloat("highscore");
                highscoreTxt.text = "Highscore: " + highscore.ToString();
            }
        }
        if (other.gameObject.CompareTag("cheesePowerUp"))
        {
            SoundManager.PlaySound("wandPicked");
            PowerUpHandler.Instance.displayPowerUp(0, 1);
            Destroy(other.gameObject);
            foreach (GameObject item in ItemGenerator.instance.getObstacles())
            {
                Instantiate(cheese, item.transform.position, item.transform.rotation);
                Destroy(item);
            }
            ItemGenerator.instance.getObstacles().Clear();
        }
        if (other.gameObject.CompareTag("reversePowerUp"))
        {
            SoundManager.PlaySound("reversePicked");
            PowerUpHandler.Instance.displayPowerUp(1, 8);
            Destroy(other.gameObject);
            isReversed = true;
            reverses.Add("a");
            StartCoroutine(waitReverse());
        }
        if (other.gameObject.CompareTag("slowPowerUp"))
        {
            SoundManager.PlaySound("slowPicked");
            PowerUpHandler.Instance.displayPowerUp(2, 5);
            Destroy(other.gameObject);
            ItemGenerator.speed -= 2f;
            ItemGenerator.spawnTime += 0.1f;
            StartCoroutine(waitSlow());

        }
        if (other.gameObject.CompareTag("magnetPowerUp"))
        {
            SoundManager.PlaySound("magnetPicked");
            PowerUpHandler.Instance.displayPowerUp(3, 5);
            Destroy(other.gameObject);
            magnets.Add("a");
            isMagnetActive = true;
            StartCoroutine(waitMagnet());
        }
        if (other.gameObject.CompareTag("giftItem"))
        {
            SoundManager.PlaySound("giftPicked");
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    //cheese power up
                    PowerUpHandler.Instance.displayPowerUp(0, 1);
                    foreach (GameObject item in ItemGenerator.instance.getObstacles())
                    {
                        Instantiate(cheese, item.transform.position, item.transform.rotation);
                        Destroy(item);
                    }
                    ItemGenerator.instance.getObstacles().Clear();
                    break;
                case 1:
                    //reverse power up
                    PowerUpHandler.Instance.displayPowerUp(1, 8);
                    reverses.Add("a");
                    isReversed = true;
                    StartCoroutine(waitReverse());
                    break;
                case 2:
                    //slow power up
                    PowerUpHandler.Instance.displayPowerUp(2, 5);
                    ItemGenerator.speed -= 2f;
                    ItemGenerator.spawnTime += 0.1f;
                    StartCoroutine(waitSlow());
                    break;
                case 3:
                    //Magnet Power Up
                    PowerUpHandler.Instance.displayPowerUp(3, 5);
                    magnets.Add("a");
                    isMagnetActive = true;
                    StartCoroutine(waitMagnet());
                    break;

            }
        }
    }

    private void Awake()
    {

        playerScore = ItemGenerator.instance.getPlayerScore();
        text = ItemGenerator.instance.getScore();
        highscoreTxt = ItemGenerator.instance.getHighScore();
        gameOverPanel = ItemGenerator.instance.getPanel();
        cheese = ItemGenerator.instance.getCheese();
        isMagnetActive = false;
        isReversed = false;
        isAnimated = false;
        isChased = false;
        line = 1;

        reverses = new List<string>();
        magnets = new List<string>();

        highscoreTxt.text = "Highscore: " + PlayerPrefs.GetFloat("highscore");
        RB = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update()
    {
        if (isReversed)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (line != 3)
                {
                    transform.position += new Vector3(0, 3, 0);
                    line++;

                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (line != 1)
                {
                    transform.position -= new Vector3(0, 3, 0);
                    line--;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (line != 3)
                {
                    transform.position += new Vector3(0, 3, 0);
                    line++;

                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (line != 1)
                {
                    transform.position -= new Vector3(0, 3, 0);
                    line--;
                }
            }
        }
    }
    IEnumerator wait()
    {
        SoundManager.audioSrc.Stop();
        SoundManager.audioSrc.clip = SoundManager.chasePlayer;
        SoundManager.audioSrc.Play();
        SoundManager.PlaySound("obstacle");
        yield return new WaitForSeconds(5);
        Destroy(catIns);
        isChased = false;
        SoundManager.audioSrc.Stop();
        SoundManager.audioSrc.clip = SoundManager.inGame;
        SoundManager.audioSrc.loop = true;
        SoundManager.audioSrc.Play();

    }
    IEnumerator animationWait()

    {
        isAnimated = true;
        yield return new WaitForSeconds(0.4f);
        isAnimated = false;
    }
    IEnumerator waitReverse()
    {
        yield return new WaitForSeconds(8);
        reverses.Remove("a");
        if (reverses.Count == 0) isReversed = false;
    }
    IEnumerator waitSlow()
    {
        yield return new WaitForSeconds(5);
        ItemGenerator.speed += 2f;
        ItemGenerator.spawnTime -= 0.1f;
    }
    IEnumerator waitMagnet()
    {
        yield return new WaitForSeconds(5);
        magnets.Remove("a");
        if (magnets.Count == 0) isMagnetActive = false;
    }
}
