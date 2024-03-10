using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtparticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public TextMeshProUGUI gameOverText;
    public Button RestartButton;
    public Button MainMenu;


    private Vector3 initialPosition;

    private UIController uiController;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();// Get references to components
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;// Set gravity modifier
        playerAudio = GetComponent<AudioSource>();
        jumpForce = PlayerPrefs.GetFloat("JumpForce", 900f);// Load jump force from PlayerPrefs or use default value for fix

        initialPosition = transform.position;

        uiController = FindObjectOfType<UIController>();// Find and get reference to UIController script

        uiController.StartTimer();
    }

    void Update()
    {
        if (!gameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))// Check for player input and conditions for jumping
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))// Check collision with ground or obstacle
        {
            isOnGround = true;
            dirtparticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))// Handle collision with obstacle
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtparticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            // Stop the timer and show game over UI elements
            uiController.StopTimer();
            gameOverText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);

            // Reset player position
            transform.position = initialPosition;
        }
    }
}