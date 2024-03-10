using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
    public void info()
    {
        Animator animator = Panel.GetComponent<Animator>(); 
        if (animator != null)
        {
            bool isOpen = animator.GetBool("Open");
            animator.SetBool("Open", !isOpen);
        }
    }
}