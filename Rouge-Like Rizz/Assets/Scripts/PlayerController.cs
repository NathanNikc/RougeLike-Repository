using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public bool isMoving;
    public Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); //the "input" variable can have axis modifiers such .x and .y because it is a vector variable
            input.y = Input.GetAxisRaw("Vertical"); //GetAxisRaw just does the same thing as get axis, but it will instantly set the value to 1 or -1 rather than ease to it. This is a design choice based on what we think looks best

            if (input != Vector2.zero)
            {
                var targetPos = transform.position; //assign targetPos to the objects position
                targetPos.x += input.x; //add input from player to target position
                targetPos.y += input.y;
            }
        }
    }
    IEnumerator Move(Vector3 targetPos)
    {
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) //while the movement input is greater than zero
        {
            targetPos = Vector3.MoveTowards //pick up in second video of rpg tutorial

        }
    }
}
