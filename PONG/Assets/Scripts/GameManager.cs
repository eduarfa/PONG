using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Vars
    [Header("Ball")] // uso de header como código html para ficar um cabeçalho no inspector
    public GameObject ball;

    [Header("Player1")]
    public GameObject playerOne;
    public GameObject goalP1;

    [Header("Player2")]
    public GameObject playerTwo;
    public GameObject goalP2;

    [Header("ScoreUI")]
    public GameObject p1ScoreText;
    public GameObject p2ScoreText;

    private int p1Score;
    private int p2Score;
    #endregion
    public void Player1Scored()
    {
        p1Score++;
        p1ScoreText.GetComponent<TextMeshProUGUI>().text = p1Score.ToString();
        Invoke("ResetPosition", 1f);
    }

    public void Player2Scored()
    {
        p2Score++;
        p2ScoreText.GetComponent<TextMeshProUGUI>().text = p2Score.ToString();
        Invoke("ResetPosition", 1f);
    }

    public void ResetPosition()
    {
        playerOne.GetComponent<MovementScript>().Reset();
        playerTwo.GetComponent<MovementScript>().Reset();
        ball.GetComponent<Ball>().Reset();
    }
}
