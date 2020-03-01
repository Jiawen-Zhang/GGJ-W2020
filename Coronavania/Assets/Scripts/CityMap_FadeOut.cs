using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityMap_FadeOut : MonoBehaviour
{
    private static string StoredName;
    public GameObject Island_C_Rebuild;

    public static void FadeOut(string GameName)
    {
        StoredName = GameName;
        GameObject Fade;
        Fade = GameObject.Find("FadeColor");
        Fade.GetComponent<Animation>().Play("FadeOut");
    }

    public static void LoadScene()
    {
        Debug.Log("StoredName");
        SceneManager.LoadScene(StoredName);
    }

    private void Start()
    {
        Island_C_Rebuild = GameObject.Find("Island_C_Rebuild");
        Island_C_Rebuild.SetActive(false);
    }

    private void Update()
    {
        if (WinController.Win)
        {
            Island_C_Rebuild.SetActive(true);
        }
    }
}
