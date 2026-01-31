using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionTimer : MonoBehaviour
{
    private float completionTime;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        completionTime = TickTock.currentTime;
        TimeSpan time = TimeSpan.FromSeconds(completionTime);
        text.text = "Time Taken: " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
