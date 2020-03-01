using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement PM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            Debug.Log("IN LAVA");
            PM.TakeDamage(1000, 1);
        }
    }
}
