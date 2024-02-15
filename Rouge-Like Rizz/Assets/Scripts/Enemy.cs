using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = .5f;
    private Rigidbody2D enemyRb;
    public Transform player;
    private float distance;
    private Vector2 movement;
    public int maxHealth = 100;
    public int currentHealth;
    public EnemyHealth healthBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        enemyRb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }
}
