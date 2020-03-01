using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameEnding : MonoBehaviour
{
    private bool CanExit;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            CanExit = true;
        }
    }

    void EndLevel()
    {
        WinController.Win = true;
        CityMap_FadeOut.FadeOut("CityMap");
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
