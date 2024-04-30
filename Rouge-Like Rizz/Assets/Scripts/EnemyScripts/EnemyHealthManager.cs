using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image enemyHealthBar;
    [SerializeField] private float enemyHealthAmount = 100f;
    [SerializeField] private float enemyMaxHealth = 100f;
    [SerializeField] private BulletDamageManager damageFinder;
    [SerializeField] public GameObject bullet;
    [SerializeField] private RizzOMeter enemyKillCounter;
    public GameObject enemy;
    private float ShockwaveDamage = 250;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        damageFinder = GameObject.FindGameObjectWithTag("DamageManager").GetComponent<BulletDamageManager>();
        enemyKillCounter = GameObject.FindGameObjectWithTag("RizzMeter").GetComponent<RizzOMeter>();
    }

    public void SetHealth(float maxHealth, float health)
    {
        this.enemyMaxHealth = maxHealth;
        this.enemyHealthAmount = health;
    }

    // Update is called once per frame
    void Update()
    {
        HealMeathods();
    }

    public void EnemyTakeDamage(float damage)
    {
        enemyHealthAmount -= damage;
        enemyHealthBar.fillAmount = enemyHealthAmount / enemyMaxHealth;
    }

    //holds almost-everything to do with healing
    public void HealMeathods()
    {
        if (enemyHealthAmount <= 0 && gameObject.tag == "Enemy")
        {
            enemyKillCounter.GainRizz(100);
            Destroy(enemy);
        }
        else if (enemyHealthAmount <= 0 && gameObject.tag == "BossLady")
        {
            enemyKillCounter.GainRizz(9999999999999999999);
            Destroy(enemy);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyTakeDamage(damageFinder.bulletDamage); //calls on TakeDamage Meathod based on collision between bullet and enemy
            Destroy(bullet);
        }
        else if (collision.gameObject.tag == "SwordShockwave")
        {
            EnemyTakeDamage(ShockwaveDamage);
        }
    }
}

