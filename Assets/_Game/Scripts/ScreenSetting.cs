using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetting : MonoBehaviour
{
    public float scaleFactor = 1.0f;

    void Start()
    {
        float screenWidth = Screen.width;
        float desiredWidth = 1920; // The width you designed for

        float scale = screenWidth / desiredWidth * scaleFactor;
        transform.localScale = new Vector3(scale, scale, 1);
    }

}
