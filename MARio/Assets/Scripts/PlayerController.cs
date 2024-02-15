using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerRb; //create a variable to house the players RigidBody
    public float jumpForce = 12f; //variable to hold the jump power
    public float gravityModifier = 2f; //variable to hold the gravity modifier used to make the jump look more realistic
    public bool isOnGround = true;
    public bool gameOver = false; //variable to hold info on if the game is over
    private Animator playerAnim; //create a new Animator variable that will house the state of the animation on the player
    public ParticleSystem oopsieDoopsie; //create a new variable to house the particle effects
    private AudioSource boioioing; //create a new variable to house the jump sound of the player
    public ParticleSystem shitter; //create a new variable to house the particle effects
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Start()
    {
      playerRb = GetComponent<Rigidbody>(); //set the variable "playerRb" to the Rigid body of the object the script is applied to (The player)
      Physics.gravity *= gravityModifier; //change the physics, of the gravity in the world, to the product of multiplying the original gravity (physics.gravity) and multiplying it by the Modifier
      playerAnim = GameObject.Find("Player").GetComponent<Animator>(); //set the player animator variable to the Animator component on the player object 
      boioioing = GetComponent <AudioSource>(); //assign the variable to the audio source found on the player
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false) //if the spacebar is pressed down AND the value of "isOnGround" == true (having only the variable name assumes the variable is true
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //add a force to the players rigid body: upwards, at a value of ten, on an impulse (suddenly)
            isOnGround = false; //sets the "isOnGround" variable to false as to stop the player from double jumping
            playerAnim.SetTrigger("Jump_trig"); //set off the trigger to make the character jump. the "jump_trig" is the condition that allows the running animation to go to the running jump animation.
            boioioing.PlayOneShot(jumpSound, .1f); //will play jump sound once if the player jumps. the sound will play at the designated speed
            shitter.Stop(); //Stop the particle effect
        }
    }


    private void OnCollisionEnter(Collision collision) //when a collision happens (First collision describes that we are looking for a collision, second "collision" is the parameter (what kind of collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //if the object collided with has the "ground" tag
        {
            isOnGround = true; //set isOnGround to true
            shitter.Play(); //play particle effects
        }
        else if (collision.gameObject.CompareTag("Obstacle")) //if the object collided with has the "obstacle" tag
        {
            gameOver = true; //set gameOver to true
            playerAnim.SetBool("Death_b", true); //set the booleen for the death animation to its true state (will activate the death anim)
            playerAnim.SetInteger("DeathType_int", 2); //set the integer for death type to 1 (chooses which specific death animation)
            oopsieDoopsie.Play(); //play the particle assigned to the Particle System variable in the unity editor (play just activates certain kinds of classes)
            boioioing.PlayOneShot(crashSound, 2.5f); //will play a crash sound at a certain speed (sound will be assigned in unity editor)
            shitter.Stop(); //stop particle effects
        }
    }
}
