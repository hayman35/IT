using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 300f;
    public TextMeshProUGUI countDownText;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        InvokeRepeating("IncrimentTime",1,1);
    }

    public void StopTimer()
    {
        CancelInvoke();
        timerIsRunning = false;
    }

    void IncrimentTime()
    {
        if(timerIsRunning)
        {
        if(currentTime > 0)
        {    
        currentTime -= 1;
        DisplayTime(currentTime);
        }
        } else 
        {
            Debug.Log("Time has run out!");
            timerIsRunning = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countDownText.text = string.Format("TimeLeft: "+"{0:00}:{1:00}", minutes, seconds);
    }
}
