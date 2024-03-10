using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour{
    private float  speed = 15; // Speed at which the object moves to the left
    private PlayerController PlayerControllerScript; // Reference to the PlayerController script
    private float leftBound = -15; // Left boundary beyond which the object is destroyed
    void Start(){
        // Get reference to the PlayerController script attached to the "Player" GameObject
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();}

    void Update(){
        if(PlayerControllerScript.gameOver == false){
     transform.Translate(Vector3.left * Time.deltaTime * speed);}// Move the object to the left based on speed
    
    if(transform.position.x <leftBound && gameObject.CompareTag("Obstacle")) { // Check if the object is beyond the left boundary and is tagged as "Obstacle"
            Destroy(gameObject);}}// Destroy the object
}
