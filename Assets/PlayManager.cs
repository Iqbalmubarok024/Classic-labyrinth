using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    int coin = 100; //TODO
    public void GameOver()
    {
        finishedText.text = "You Lose";
        finishedCanvas.SetActive(true);
    }
     public void PlayerWin()
    {
        finishedText.text = "Winner !\nScore: " + GetScore();
        finishedCanvas.SetActive(true);
    }

    private int GetScore()
    {
        return coin * 10;
    }
}