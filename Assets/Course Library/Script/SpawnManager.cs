using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float StartDelay = 2;
    private float RepeatRate = 2;
    private PlayerController PlayerControllerScript;
    void Start(){
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle(){
        if (PlayerControllerScript.GameOver == false) { 
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);}}
}
