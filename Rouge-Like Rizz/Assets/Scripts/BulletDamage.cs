using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private BulletDamageManager damageFinder;
    [SerializeField] public GameObject bullet;
    [SerializeField] private EnemyHealthManager takeDamageMeathod;


    // Start is called before the first frame update
    public void Start()
    {
       takeDamageMeathod = GameObject.FindGameObjectWithTag("EnemyHealthBar").GetComponent<EnemyHealthManager>();
       damageFinder = GameObject.FindGameObjectWithTag("DamageManager").GetComponent<BulletDamageManager>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamageMeathod.EnemyTakeDamage(damageFinder.bulletDamage); //calls on TakeDamage Meathod based on collision between bullet and enemy
            Destroy(bullet);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(bullet);
        }
    }
}
