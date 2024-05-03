using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float damage = 5f;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerHealthManager playerHealthManager;
    [SerializeField]
    private AIPath AIPath;
    [SerializeField] 
    private EnemyHealthManager enemyHealthManager;
    [SerializeField]
    private RizzOMeter rizzOMeter;

    private GameObject player;
    private GameObject playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Healer");
        playerController = player.GetComponent<PlayerController>();
        playerHealthManager = playerHealth.GetComponent<PlayerHealthManager>();
        rizzOMeter = GameObject.FindGameObjectWithTag("RizzMeter").GetComponent<RizzOMeter>();
        AIPath = this.GetComponent<AIPath>();
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void SetEnemyValues()
    {
        enemyHealthManager.SetHealth(enemyData.enemyHealth, enemyData.enemyHealth);
        damage = enemyData.enemyDamage;
        AIPath.maxSpeed = enemyData.enemySpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerHealthManager.TakeDamage(damage);
            rizzOMeter.LoseRizz(Random.Range(2500, 5000));
            playerController.GoInvincible();
        }
    }

}
