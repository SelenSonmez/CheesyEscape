using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    public bool hasTarget;
    public GameObject target;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(GameObject.FindGameObjectsWithTag("Player").Length != 0)
        target = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    // Update is called once per frame
    void Update()
    {

        if (hasTarget)
        {
            Vector2 targetDirection = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * 20f;
        }
        else
        {
            transform.Translate(Vector2.down * ItemGenerator.speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("endLine"))
        {
            Destroy(this.gameObject);
        }
    }
    public void setTarget()
    {
        hasTarget = true;
    }
}
