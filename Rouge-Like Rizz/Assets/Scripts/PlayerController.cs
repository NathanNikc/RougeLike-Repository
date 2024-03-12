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
    public float enemyDamage = 30f;
    public Transform playerTransform;

    [Header("I-Frames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("DashSettings")]
    [SerializeField] float dashSpeed = 50f;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] float dashDuration = .3f;
    [SerializeField] int dashCooldown = 3;
    bool isDashing;
  

    void Start()
    {
        playerTransform = transform;
        spriteRend = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        playerHealthMeathods = GameObject.FindGameObjectWithTag("Healer").GetComponent<PlayerHealthManager>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        playerRb.velocity = new Vector2(playerMovement.x * dashSpeed, playerMovement.y * dashSpeed);
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
    }

    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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

    public void OnCollisionEnter2D(Collision2D collision) //give player i-frames
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
