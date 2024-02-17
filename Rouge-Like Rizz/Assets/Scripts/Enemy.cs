using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = .5f;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private float distance;
    private Vector2 movement;
    public int maxHealth = 100;
    public int currentHealth;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        Vector3 direction = playerTransform.position - transform.position;
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
