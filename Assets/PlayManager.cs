using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    
    int coin = 100; 
    public float timeLimit = 60f; 
    public TMP_Text timerText; 

    private float currentTime; 
    private bool isRunning; 

    private void Start()
    {
        ResetTimer();
        StartTimer();
    }

     private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
            }
            if (currentTime == 0f)
            {
                GameOver();
            }

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        isRunning = false;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int menit = Mathf.FloorToInt(currentTime / 60f);
        int detik = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00} : {1:00}", menit, detik);
    }
    public void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        gameOverEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        gameOverEvent.OnInvoked.RemoveListener(PlayerWin);
    }
    public void GameOver()
    {
        finishedText.text = "You Lose\n" + "Time : " + currentTime + "s";
        finishedCanvas.SetActive(true);
    }
     public void PlayerWin()
    {
        finishedText.text = "Winner\n" + "Time : " + currentTime + "s";
        finishedCanvas.SetActive(true);
    }

    // private int GetScore()
    // {
    //     return coin * 10;
    // }

}
