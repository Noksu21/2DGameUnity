using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour{
    private float  speed = 15;
    private PlayerController PlayerControllerScript;
    private float leftBound = -15;
    void Start(){
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();}

    void Update(){
        if(PlayerControllerScript.GameOver == false){
     transform.Translate(Vector3.left * Time.deltaTime * speed);}
    
    if(transform.position.x <leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);}}
}
