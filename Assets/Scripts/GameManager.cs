using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject p1ScoreText;
    [SerializeField] private GameObject p2ScoreText;
    [SerializeField] private GameObject p3ScoreText;
    [SerializeField] private GameObject p4ScoreText;
    public static int p1Score;
    public static int p2Score;
    public static int p3Score;
    public static int p4Score;

    //Ready
    private float readyTimer = 3.0f;
    [SerializeField] private GameObject count3;
    [SerializeField] private GameObject count2;
    [SerializeField] private GameObject count1;
    [SerializeField] private GameObject go;
    //InGame
    private float inGameTimer = 60.0f;
    [SerializeField] private GameObject timer;

    public enum State
    {
        Ready,
        InGame,
        Finish
    }
    public static State gameState;
    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;
        p3Score = 0;
        p4Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case State.Ready:
                readyTimer -= Time.deltaTime;
                if(readyTimer < 3 && readyTimer >2)
                {
                    count3.SetActive(true);
                }
                if (readyTimer < 2 && readyTimer > 1)
                {
                    count3.SetActive(false);
                    count2.SetActive(true);
                }
                if (readyTimer < 1 && readyTimer > 0)
                {
                    count2.SetActive(false);
                    count1.SetActive(true);
                }
                if (readyTimer < 0)
                {
                    count1.SetActive(false);
                    go.SetActive(true);
                }
                if (readyTimer < -1)
                {
                    go.SetActive(false);
                    gameState = State.InGame;
                }

                DisplayScore();
                break;
            case State.InGame:
                timer.SetActive(true);
                inGameTimer -= Time.deltaTime;
                timer.GetComponent<Text>().text = String.Format("{0:00}", inGameTimer);
                DisplayScore();
                break;
            case State.Finish:
                break;
        }
        
    }

    private void DisplayScore()
    {
        p1ScoreText.GetComponent<Text>().text = String.Format("{0:000}", p1Score);
        p2ScoreText.GetComponent<Text>().text = String.Format("{0:000}", p2Score);
        p3ScoreText.GetComponent<Text>().text = String.Format("{0:000}", p3Score);
        p4ScoreText.GetComponent<Text>().text = String.Format("{0:000}", p4Score);
    }
}
