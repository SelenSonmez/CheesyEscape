using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private Animator animator;
    
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
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("obstacle");
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
