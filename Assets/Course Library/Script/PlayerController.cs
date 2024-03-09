using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Rigidbody PlayerRb;
    public float JumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool GameOver =false;
    private Animator playerAnim;

   
    void Start(){
        PlayerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;}

   
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;}}
        private void OnCollisionEnter(Collision collision){
        isOnGround = true;}

    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            playerAnim.SetTrigger("Jump_trig");}
        else if (collision.gameObject.CompareTag("Obstacle")){
            GameOver = true;
            Debug.Log("Game Over!");}}
}
