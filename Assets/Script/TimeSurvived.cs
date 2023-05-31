using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSurvived : MonoBehaviour
{
    public TMP_Text timeText;
    private float elapsedTime = 0f;
    public bool isGameRunning = true;
    private bool isGamePaused = false;
    public TMP_Text playertimetext;
 //   public TMP_Text timerttt;
    public GameObject gameoverpanel;
    public GameObject pause;
    

    public float timeSurvived = 15f;
    public float scorePerSecond = 15f;
   
    private void Update()
    {
        if (isGameRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeUI();
        }      

    }

    private void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);

        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

        timeText.text = timeString;
        timeSurvived = timeString.Length;
        // Store the elapsed time in PlayerPrefs
        PlayerPrefs.SetFloat("ElapsedGameTime", elapsedTime);
    }

    public void PauseGame()
    {
        isGameRunning = false;
        Debug.Log("game pause");
    }

    public void ResumeGame()
    {
        isGameRunning = true;
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f; // Pause the game by setting the time scale to 0
            PauseGame(); // Pause the timeSurvived script
        }
        else
        {
            Time.timeScale = 1f; // Resume the game by setting the time scale to 1
            ResumeGame(); // Resume the timeSurvived script
        }
    }

    public void Gameover()
    {
        // Retrieve the elapsed time from PlayerPrefs
        float elapsedGameTime = PlayerPrefs.GetFloat("ElapsedGameTime");

        // Convert the elapsed time to the desired format
        int minutes = Mathf.FloorToInt(elapsedGameTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedGameTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedGameTime * 100f) % 100f);

        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

        // Update the UI text with the elapsed time
        playertimetext.text = timeString;

        // Show the gameover panel
        gameoverpanel.SetActive(true);

        pause.SetActive(false);

    }
}

