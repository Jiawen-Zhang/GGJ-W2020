using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    private bool CanExit;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            CanExit = true;
        }
    }

    void EndLevel()
    {
        WinController.Game1Done = true;
        CityMap_FadeOut.FadeOut("1-2");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanExit)
        {
            if (Input.GetButtonDown("Vertical"))
            {
                EndLevel();
            }
        }
    }
}
