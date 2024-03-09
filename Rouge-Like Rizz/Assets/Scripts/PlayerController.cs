using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Rigidbody2D playerRb;
    private Vector2 playerMovement;
    public PlayerHealthManager playerHealthMeathods;
    public PlayerHealthManager ouchy;
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public float enemyDamage = 30f;
    public float dashDowntime = 10f;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        playerHealthMeathods = GameObject.FindGameObjectWithTag("Healer").GetComponent<PlayerHealthManager>();
    }

    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        moveSpeed = 10f;
        yield return new WaitForSeconds(1f);
        moveSpeed = 5f;
        yield return new WaitForSeconds(dashDowntime);
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
            playerHealthMeathods.TakeDamage(30f); //increase damage taken per hit after i-frames are applied
            StartCoroutine(Invulnerability());
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        {
            for (int i = 0; i < numberOfFlashes; i++) 
            {
                spriteRend.color = new Color(1, 0, 0, 0.75f);
                yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes));
                spriteRend.color = Color.white;
                yield return new WaitForSeconds(iFrameDuration/ (numberOfFlashes));
            }
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }
}
