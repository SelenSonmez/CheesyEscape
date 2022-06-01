using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;
    private Animator animator;
    
    public void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * obstacleGenerator.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("collision" +collision.gameObject.name);
        if (collision.gameObject.CompareTag("nextLine")){
            obstacleGenerator.generateObstacle();
        }
        if (collision.gameObject.CompareTag("endLine"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
           StartCoroutine(Animate());
        }
        
    }
    IEnumerator Animate()
    {
        Debug.Log("girdi");
        animator.SetTrigger("isHit");
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
