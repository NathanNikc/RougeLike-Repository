using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 3.5f;
    private Rigidbody2D playerRb;
    private Vector2 playerMovement;
    public PlayerHealthManager playerHealthMeathods;
    public PlayerHealthManager ouchy;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerHealthMeathods = GameObject.FindGameObjectWithTag("Healer").GetComponent<PlayerHealthManager>();
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
            playerHealthMeathods.PickUpPot();
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionStay2D(Collision2D collision) //give player i-frames
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealthMeathods.TakeDamage(1f); //increase damage taken per hit after i-frames are applied
        }
    }
}
