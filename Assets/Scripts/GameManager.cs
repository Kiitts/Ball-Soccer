using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int kickLeft;
    public TextMeshProUGUI kickLeftText;
    public TextMeshProUGUI timerText;
    public bool isGameActive;
    public bool ballTouchGoal;
    public bool timerStarted;
    public GameObject pauseCanvas;

    private GameObject _gameOverObject, _winObject;
    private GameObject _gameCanvas;
    private bool _playerWon;
    private int _timerCount = 5;
    private bool _isGamePause;

    private void Start() 
    {
        // update text
        UpdateKickLeftText(0);
        // initalize values
        _gameOverObject = GameObject.Find("Canvas").transform.Find("Game Over").gameObject;
        _gameCanvas = GameObject.Find("Canvas");
        _winObject = GameObject.Find("Canvas").transform.Find("Win").gameObject;
        isGameActive = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        
        MainManager.instance.SaveLevel(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Increment the score and display new score on canvas
    /// </summary>
    /// <param name="incrementScore">decrement score with this input</param>
    public void UpdateKickLeftText(int decrementTouch = 1)
    {
        kickLeft -= decrementTouch;
        kickLeftText.text = $"Kick Left: {kickLeft}";
        if(kickLeft == 0)
        {
            StartCoroutine("WaitForGoal");
        }
    }

    /// <summary>
    /// When the kick is 0 must wait 5 seconds first
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForGoal()
    {
        float timeStamp = Time.time;
        float timeSeconds = timeStamp;
        isGameActive = false;
        while(Time.time < timeStamp + 5)
        {
            if(!timerStarted)
            {
                UpdateTimer(0);
                timerStarted = true;
            }
            if(ballTouchGoal)
            {
                Win();
                break;
            }
            if(Time.time > timeSeconds + 1)
            {
                UpdateTimer();
                timeSeconds = Time.time;
            }
            yield return null;
        }
        timerStarted = false;
        if(!ballTouchGoal)
        {
            UpdateTimer();
            GameOver();
        }
    }

    /// <summary>
    /// Game over, prompt message and button
    /// </summary>
    void GameOver()
    {
        _gameOverObject.SetActive(true);
        Cursor.visible = true;
    }

    /// <summary>
    /// Game won, prompt message and buttons
    /// </summary>
    public void Win()
    {
        if(!_playerWon)
        {
            _playerWon = true;
            _winObject.SetActive(true);
        }
        isGameActive = false;
        Cursor.visible = true;
    }

    /// <summary>
    /// Update the timer and displays it
    /// </summary>
    /// <param name="decrement">decrement the timer by this value</param>
    void UpdateTimer(int decrement = 1)
    {
        _timerCount -= decrement;
        timerText.text = _timerCount.ToString();
    }

    /// <summary>
    /// When escape key is pressed pause or unpause the game
    /// </summary>
    void OnPause()
    {
        if(!_isGamePause)
        {
            _isGamePause = true;
            Time.timeScale = 0;
            _gameCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            _isGamePause = false;
            Time.timeScale = 1;
            _gameCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            if(isGameActive)
            {
                Cursor.visible = false;
            }
        }
    }
}
