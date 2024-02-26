using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 3.5f;
    private Rigidbody2D playerRb;
    private Vector2 playerMovement;
    public PlayerHealthManager healCounter;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        healCounter = GameObject.FindGameObjectWithTag("Healer").GetComponent<PlayerHealthManager>();
    }

    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))

        {
            moveSpeed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3.5f;
        }
    }

    public void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + (playerMovement * moveSpeed * Time.fixedDeltaTime));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPot")
        {
            healCounter.PickUpPot();
            Destroy(other.gameObject);
        }
    }
}
