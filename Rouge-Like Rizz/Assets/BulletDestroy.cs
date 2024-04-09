using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] public GameObject bullet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(bullet);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(bullet);
        }
    } 
}
