using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D playerRb;
    Vector2 playerMovement;

    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate() //will be called 50 times a second and not based on frames
    {
        playerRb.MovePosition(playerRb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
