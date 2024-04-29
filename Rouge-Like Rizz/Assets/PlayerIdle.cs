using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : StateMachineBehaviour
{
    [SerializeField] PlayerController player;
    private Animator playerAnim;
    private bool isMoving = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAnim = player.GetComponent<Animator>();
    }

    //  OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("isWalkingRight");
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            playerAnim.SetTrigger("IsWalkingAway");
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("IsWalkingToward");
            isMoving= true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("IsWalkingLeft");
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
        }

        if (!isMoving) 
        {
            playerAnim.SetTrigger("IsNotMoving");
        }
    }
}
