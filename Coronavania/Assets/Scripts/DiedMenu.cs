using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    public PlayerMovement PM;
    public GameObject DiedMenuUI;

    private void Start()
    {
        DiedMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.dead == true)
        {
            DiedMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        PM.dead = false;
        Time.timeScale = 1f;
        CityMap_FadeOut.FadeOut("1-2");
    }

    public void LoadMap()
    {
        PM.dead = false;
        Time.timeScale = 1f;
        CityMap_FadeOut.FadeOut("CityMap");
    }

    public void QuitGame()
    {
        PM.dead = false;
        Time.timeScale = 1f;
        CityMap_FadeOut.FadeOut("WelcomeScreen");
    }

}
