using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private Animator animator;
    bool isAnimated = false;
    public GameObject cat;
    public Transform startPositon;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * ItemGenerator.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.gameObject.CompareTag("endLine"))
        {
            ItemGenerator.instance.getObstacles().Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isAnimated)
                return;
            isAnimated = true;
            
            ItemGenerator.instance.getObstacles().Remove(this.gameObject);
            StartCoroutine(Animate());
        }     
    }

    IEnumerator Animate()
    {
        animator.SetTrigger("isHit");     
        yield return new WaitForSeconds(0.4f);

        Destroy(this.gameObject);
        
    }
}
