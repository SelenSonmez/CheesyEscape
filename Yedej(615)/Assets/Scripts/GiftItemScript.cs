using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftItemScript : MonoBehaviour
{
    private Animator animator;
    bool isAnimated = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * ItemGenerator.speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
            //SoundManager.PlaySound("obstacle");
            //ItemGenerator.instance.getObstacles().Remove(this.gameObject);
            StartCoroutine(Animate());
        }
    }
    IEnumerator Animate()
    {
        Debug.Log("Girdi");
        animator.SetTrigger("isPicked");
        yield return new WaitForSeconds(1f);
        Debug.Log("Destroy");
        Destroy(this.gameObject);

    }
}
