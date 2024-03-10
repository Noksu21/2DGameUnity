using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public void OnPlayButton(){
        //function for button to load maingame scene
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void OnQuitButton(){ 
        //function for button to quit
        Application.Quit();
    }
    public void info(){
        //function for button to get animation for panel 
        Animator animator = Panel.GetComponent<Animator>(); 
        if (animator != null)
        {
            // Get the current value of the "Open" parameter from the Animator
            bool isOpen = animator.GetBool("Open");
            // Toggle the value of the "Open" parameter in the Animator
            animator.SetBool("Open", !isOpen);
        }
    }
}