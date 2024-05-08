using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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
    private EnemyHealthManager enemyHealthManager;
    private GameObject player;
    private GameObject playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Healer");
        playerController = player.GetComponent<PlayerController>();
        playerHealthManager = playerHealth.GetComponent<PlayerHealthManager>();
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerHealthManager.TakeDamage(damage);
            playerController.GoInvincible();
        }
    }

}
