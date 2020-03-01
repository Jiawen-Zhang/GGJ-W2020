using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackWelcome : MonoBehaviour
{
    private void OnMouseUp()
    {
        CityMap_FadeOut.FadeOut("WelcomeScreen");
    }
}
