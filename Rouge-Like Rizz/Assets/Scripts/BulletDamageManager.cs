using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageManager : MonoBehaviour
{
    [SerializeField] public float bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
