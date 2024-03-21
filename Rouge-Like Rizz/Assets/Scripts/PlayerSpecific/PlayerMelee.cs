using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public EnemyHealthManager takeMeleeDamageMeathod;
    public float swordDamage = 40f;
    public float swingDowntime = 2f;
    public Transform sword;
    private bool canSwing = true;
    public Renderer swordUI;

    private void Start()
    {
        takeMeleeDamageMeathod = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canSwing == true)
        {
            Attack();
            StartCoroutine(SwordDowntime());
        }
    }

    private void Attack()
    {
        swordUI.enabled = false;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) 
        {
            takeMeleeDamageMeathod.EnemyTakeDamage(swordDamage);
        }
    }

    private IEnumerator SwordDowntime()
    {
        canSwing = false;
        yield return new WaitForSeconds(swingDowntime);
        canSwing = true;
        swordUI.enabled = true;
    }

    void OnDrawGizmosSelected()
    {
       if (attackPoint == null) 
            return;

       Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
