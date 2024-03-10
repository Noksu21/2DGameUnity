using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int time = 0;
    public Text timer;
    public Text highscore;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            highscore.text = "No High Scores Yet";
        }
        StartTimer();
    }

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrementTime", 1, 1);
    }

    public void StopTimer()
    {
        CancelInvoke();
        if (PlayerPrefs.GetInt("Highscore") < time)
        {
            SetHighscore();
        }
    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time);
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore.text = "No High Scores Yet";
    }

    void IncrementTime()
    {
        time += 1;
        timer.text = "Time: " + time;
    }
    public void RestartGame()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene("MainMenu");
    }
}
