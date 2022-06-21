using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        line = PlayerScript.line;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.isReversed)
        {
            if (PlayerScript.isChased)
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
        }
        else
        {
            if (PlayerScript.isChased)
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
    }
}
