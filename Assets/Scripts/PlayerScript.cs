using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public GameObject explosion;
    public int line = 1;
    Rigidbody2D RB;
    public Text text;
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("cheese"))
      {
            Destroy(other.gameObject);
            score++;
            text.text = "Score: " + score;
      }
      if (other.gameObject.CompareTag("apple"))
      {
            Destroy(other.gameObject);
            score--;
            text.text = "Score: " + score;
      }
    }
    
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (line != 3)
            {
                transform.position += new Vector3(0,3,0);
                line++;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            if (line != 1)
            {
                transform.position -= new Vector3(0,3,0);
                line--;
            }
        }
    }
}
