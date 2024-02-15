using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obstaclePrefab; //Variable to house the game object (obstacles)
    private Vector3 spawnPos = new Vector3(25, 2, 0); //spawn position for the obstacle
    private float startDelay = 3f; //variable to house the amount of time it will take for obstacles to start spawning
    private float repeatRate = 1.5f; //variable to house the amount of time it will take for objects to spawn after the first one is spawned
    private PlayerController playerControllerScript; //create a new player controller variable

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); //keep calling the "spawnObstacle" meathod, after the start delay, repeated every repeatrated
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //assign the playercontrollerscript variable to the player controller script found on the player object
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) //if the gameover variable found in the player controller script is false
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); //spawn an instance: of the prefab, at the spawn position, in the rotation that the prefab is already set at
        }
    }
}
