using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSwitch : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    
    public GameObject blocker1;
    public GameObject blocker2;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            animator.SetBool("IsCompressed", true);
            Destroy(blocker1);
            Destroy(blocker2);
        }
    }
}
