using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int time = 0;
    public Text timer; // ui text displayung the timer
    public Text highscore; //ui text displaying the high score

    void Start()
    {
        //check if high score exist
        if (PlayerPrefs.HasKey("Highscore"))
        {
            // display high score
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            //if not hight score exists
            highscore.text = "No High Scores Yet";
        }
        //timer start when game start
        StartTimer();
    }

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrementTime", 1, 1); // Invoke the IncrementTime method every second
    }

    public void StopTimer()
    {
        CancelInvoke();
        // Check if the current time is higher than the high score
        if (PlayerPrefs.GetInt("Highscore") < time)
        {
            SetHighscore();// Set the new high score
        }
    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time); //save new hight score in playerprefs
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString(); //update ui text
    }
    void IncrementTime()
    {
        time += 1;
        timer.text = "Time: " + time;
    }
    //restart game met
    public void RestartGame()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0); // reset the gravity import i was stuck with this one for long time my charactert dint jump after reset but this seems to fix it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //main menu met
    public void MainMenu()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);// reset the gravity
        SceneManager.LoadScene("MainMenu");
    }
}
