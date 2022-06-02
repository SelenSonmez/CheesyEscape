using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * ItemGenerator.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("endLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
