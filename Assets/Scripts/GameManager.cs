using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject fish_1;
    [SerializeField] private GameObject fish_5;
    [SerializeField] private GameObject fish_10;
    [SerializeField] private GameObject fish_15;
    [SerializeField] private GameObject fish_30;
    private float fishInterval = 1;
    //Finish
    [SerializeField] private GameObject finish;
    [SerializeField] private GameObject result;
    [SerializeField] private GameObject p1win;
    [SerializeField] private GameObject p2win;
    [SerializeField] private GameObject p3win;
    [SerializeField] private GameObject p4win;
    [SerializeField] private GameObject goResult;
    private float finishTimer = 0.0f;
    public enum State
    {
        Ready,
        InGame,
        Finish,
        Next
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
        
        Debug.Log(p1Score);
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
                fishInterval -= Time.deltaTime;
                if(fishInterval < 0)
                {
                    CreateFish();
                    fishInterval = 1;
                }
                timer.GetComponent<Text>().text = String.Format("{0:00}", inGameTimer);
                DisplayScore();
                if(inGameTimer < 0)
                {
                    gameState = State.Finish;
                    finish.SetActive(true);
                }
                break;
            case State.Finish:
                finishTimer += Time.deltaTime;
                if(finishTimer > 2)
                {
                    finish.SetActive(false);
                }
                if(finishTimer > 4)
                {
                    result.SetActive(true);
                    goResult.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    result.SetActive(false);
                    Winner();
                    gameState = State.Next;
                }
                break;
            case State.Next:
                goResult.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
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

    private void CreateFish()
    {
        int rndFish = UnityEngine.Random.Range(0,20);
        int rndX = UnityEngine.Random.Range(0, 2);
        float x = -10;
        if(rndX == 1)
        {
            x = 10;
        }
        float rndY = UnityEngine.Random.Range(-4, 1);
        if(rndFish >= 0 && rndFish <=  9)
        {
            Instantiate(fish_1, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 10 && rndFish <= 13)
        {
            Instantiate(fish_5, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 14 && rndFish <= 16)
        {
            Instantiate(fish_10, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish >= 17 && rndFish <= 18)
        {
            Instantiate(fish_15, new Vector2(x, rndY), Quaternion.identity);
        }
        if (rndFish == 19)
        {
            Instantiate(fish_30, new Vector2(x, rndY), Quaternion.identity);
        }
    }

    private void Winner()
    {
        int no = 1;
        float winner = p1Score;
        if(winner < p2Score)
        {
            winner = p2Score;
            no = 2;
        }
        if(winner < p3Score)
        {
            winner = p3Score;
            no = 3;
        }
        if (winner < p4Score)
        {
            winner = p4Score;
            no = 4;
        }
        if(no == 1)
        {
            p1win.SetActive(true);
        }
        if (no == 2)
        {
            p2win.SetActive(true);
        }
        if (no == 3)
        {
            p3win.SetActive(true);
        }
        if (no == 4)
        {
            p4win.SetActive(true);
        }
    }
}
