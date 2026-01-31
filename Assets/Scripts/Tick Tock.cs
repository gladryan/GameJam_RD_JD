using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class TickTock : MonoBehaviour
{
    private bool timerActive = true;
    static public float currentTime;
    [SerializeField] private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
     if (timerActive)
        {
            currentTime += Time.deltaTime;
        }
        text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void startTimer()
    {
        timerActive = true;
    }

    public void stopTimer()
    {
        timerActive = false;
    }
}
