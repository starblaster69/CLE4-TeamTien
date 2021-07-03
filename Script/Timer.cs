using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    //Pre-Race Countdown
    bool countdownActive = true;
    float currentCountdown;
    public int countdownStartSeconds;
    public TMP_Text currentCountdownText;

    //Timer
    bool timerActive = false;
    float currentTime;
    public TMP_Text currentTimeText;

    //Score
    int Score;
    public TMP_Text scoreText;
    public float multiplier = 5;

    public GameObject StartRaceCountdown;
    public GameObject LapTimer;
    public GameObject CarControls;

    // Start is called before the first frame update
    void Start()
    {
        currentCountdown = countdownStartSeconds;
        currentTime = 0;
        StartCoroutine(SetTimerInactive());
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown Updater
        if (countdownActive == true) {    
            currentCountdown = currentCountdown - Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentCountdown);
            currentCountdownText.text = time.Seconds.ToString();
        //stops timer at 0 if counting down:
            if (currentCountdown < 1) {
                currentCountdownText.text = "start!";
                countdownActive = false;
                timerActive = true;
                LapTimer.SetActive(true);
                CarControls.SetActive(true);
                Debug.Log("Countdown Finished!");
            }
        }
        
        //Timer Updater
        if (timerActive == true) {
            currentTime = currentTime + Time.deltaTime;
        //stops timer at 0 if counting down:
            //if (currentTime <= 0) {
                //timerActive = false;
                //Start();
                //Debug.Log("Timer Finished!");
            //}
        }
        TimeSpan timer = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = timer.ToString(@"mm\:ss\:fff");

        //Score Updater
        Score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = Score.ToString();
    }
    
    public IEnumerator SetTimerInactive() {
        yield return new WaitForSeconds(6);
        StartRaceCountdown.SetActive(false);
    }

    public void StartTimer() {
        timerActive = true;
    }

    public void StopTimer() {
        timerActive = false;
    }
}
