using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveDamage : MonoBehaviour
{
    public float shockwaveDamage = 100f;
    private EnemyHealthManager shockwaveHurt;

    // Start is called before the first frame update
    void Start()
    {
        shockwaveHurt = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.tag == "Enemy")
        {
            shockwaveHurt.EnemyTakeDamage(shockwaveDamage);
        }
    }
}
