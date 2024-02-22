using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private EnemyHealthManager takeDamageMeathod;
    public GameObject bullet;
    private float bulletDamage = 50f;

    // Start is called before the first frame update
    public void Start()
    {
        takeDamageMeathod = GameObject.FindGameObjectWithTag("DamageTaker").GetComponent<EnemyHealthManager>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamageMeathod.EnemyTakeDamage(bulletDamage); //calls on TakeDamage Meathod based on collision between bullet and enemy
            Destroy(bullet);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(bullet);
        }
    }
}
