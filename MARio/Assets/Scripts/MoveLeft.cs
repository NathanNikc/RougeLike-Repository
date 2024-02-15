using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 30f; //create a variable that will house the speed of the object
    private PlayerController playerControllerScript; //Create a new PlayerController Variable which will house the ability to control a player (kinda like a rigidbody)
    private float leftBound = -15f; //create a new variable to house the left boundary

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //assign the playerControllerScript to the PlayerController script found on the player object
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) //if the gameOver variable in the playerControlletScript is false
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); //move (Translate) the transform (object): left, over time, at a speed when the game is not over
        }    
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) //if the position of the object on the x axis is less than the leftbound AND the game object has the "obstacle" tag
        {
            Destroy(gameObject); //destroy the game object
        }
    }

     
}
