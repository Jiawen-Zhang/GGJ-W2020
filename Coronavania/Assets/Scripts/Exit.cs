using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnMouseUp()
    {
        // For publish
        Application.Quit();

        // For test use only
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
