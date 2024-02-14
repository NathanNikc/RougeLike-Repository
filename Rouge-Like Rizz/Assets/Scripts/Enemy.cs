using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = .5f;
    public Rigidbody2D enemyRb;
    private GameObject player;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
