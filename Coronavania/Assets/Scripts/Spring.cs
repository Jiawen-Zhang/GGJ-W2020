using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public int speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            animator.SetBool("IsCompressed", true);
            collision.gameObject.GetComponent<Rigidbody2D>
                     ().AddForce(new Vector2(0f, speed));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            animator.SetBool("IsCompressed", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
