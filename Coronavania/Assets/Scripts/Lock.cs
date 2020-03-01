using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static bool canUnlock = false;
    public GameObject lockHead;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            if(canUnlock) {
                Destroy(gameObject);
                Destroy(lockHead);
            }
        }
    }
}
