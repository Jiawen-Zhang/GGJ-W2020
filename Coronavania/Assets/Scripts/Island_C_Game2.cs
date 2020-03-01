using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_C_Game2 : MonoBehaviour
{
    private void OnMouseUp()
    {
        if (WinController.Game1Done)
        {
            CityMap_FadeOut.FadeOut("1-2");
        }
    }
}
