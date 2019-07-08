using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config parameters
    [SerializeField] TextMeshProUGUI player1ScoreText;
    [SerializeField] TextMeshProUGUI player2ScoreText;
    
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f; //we will use it to alter time scale

    //state variables
    private int currPlayer1Score;
    private int currPlayer2Score;

    [SerializeField] TextMeshProUGUI winner;

    //cached references
    LevelManager levelManager;

    //prevent having more than one game status and preserve score through levels. Not neccessary at the moment
    private void Awake()
    {
        /*
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        player1ScoreText.text = currPlayer1Score.ToString();
        player2ScoreText.text = currPlayer2Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        if (player1ScoreText.text.Equals("7"))
        {
            winner.text = "player1 wins!";
            levelManager.SetIsWon(true);

        }
        else if (player2ScoreText.text.Equals("7"))
        {
            winner.text = "player2 wins!";
            levelManager.SetIsWon(true);
        }


    }

    //true for player1, false for player2
    public void AddToScore(bool player)
    {
        if (player)
        {
            currPlayer1Score += 1;
            player1ScoreText.text = currPlayer1Score.ToString();
        }

        else
        {
            currPlayer2Score += 1;
            player2ScoreText.text = currPlayer2Score.ToString();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
