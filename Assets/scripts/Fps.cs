using System;
using UnityEngine;

public class Fps : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GUIStyle style;
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 300;
        style.normal.textColor = Color.white;

    }

    // Update is called once per frame
    void OnGUI()
    {
       float fps = 1.0f/Time.deltaTime;
       GUI.Label(new Rect(10, 10, 100, 20), "Fps: " + Math.Round(fps) ); 
    }
    void Update()

    {
        
    }
}
