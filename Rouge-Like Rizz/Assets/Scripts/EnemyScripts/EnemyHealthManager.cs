using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image enemyHealthBar;
    [SerializeField] private float enemyHealthAmount = 100f;
    private float enemyMaxHealth = 100f;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

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
        enemyHealthBar.fillAmount = enemyHealthAmount / 100f;
    }


    //holds almost-everything to do with healing
    public void HealMeathods()
    {
        if (enemyHealthAmount <= 0)
        {
            Destroy(enemy);
        }
    }
}

