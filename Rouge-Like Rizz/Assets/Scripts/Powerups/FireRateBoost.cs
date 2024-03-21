using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateBoost : MonoBehaviour
{
    public BulletAim fireRateAdjust;

    private void Start()
    {
        fireRateAdjust = GameObject.FindGameObjectWithTag("Bullet").GetComponent<BulletAim>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Pickup();
        }
    }

    void Pickup()
    {
        fireRateAdjust.shootDelay = .15f;
        
        Destroy(gameObject);
    }
}
