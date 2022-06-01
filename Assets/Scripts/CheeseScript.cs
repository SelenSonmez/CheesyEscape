using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * obstacleGenerator.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            obstacleGenerator.generateObstacle();
        }
        if (collision.gameObject.CompareTag("endLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
