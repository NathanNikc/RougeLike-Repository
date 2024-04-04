 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject swordShockwavePrefab;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private BulletDamageManager damageAdjust;
    [SerializeField] private BulletAim swordSwingPoint;
    static bool hasRing = false;
    static bool isUsingRing = false;
    static bool hasRage = false;
    static bool isUsingRage = false;
    static bool hasSword = false;
    static bool isUsingSword = false;
    static bool hasBook = false;
    public float shootDelay = .5f;
    public float shockwaveSpeed = 10f;


    // Start is called before the first frame update
    public void Start()
    {
        spriteRend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        damageAdjust = GameObject.FindGameObjectWithTag("DamageManager").GetComponent<BulletDamageManager>();
        swordSwingPoint = GameObject.FindGameObjectWithTag("Bullet").GetComponent<BulletAim>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && hasRing == true && isUsingRing == false)
        {
            StartCoroutine(InvincibleAF());
        }

        if (Input.GetKeyDown(KeyCode.X) && hasRage == true && isUsingRage == false)
        {
            StartCoroutine(Angery());
        }

        if (Input.GetKeyDown(KeyCode.Z) && hasSword == true && isUsingSword == false)
        {
            StartCoroutine(SwordGoSwing());
        }

        if (hasBook == true)
        {
            shootDelay = .15f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ring")
        {
            Destroy(other.gameObject);
            hasRing = true;
            //need to give player powerup in bottom left to prompt them letting them know they can now become invicible for a short time
        }

        if (other.tag == "Rage")
        {
            Destroy(other.gameObject);
            hasRage = true;
        }

        if (other.tag == "Book")
        {
            Destroy(other.gameObject);
            hasBook = true;
        }

        if (other.tag == "Sword")
        {
            Destroy(other.gameObject);
            hasSword = true;
        }
    }

    public IEnumerator SwordGoSwing()
    {
        isUsingSword = true;
        {
            GameObject swordSwing = Instantiate(swordShockwavePrefab, swordSwingPoint.firePoint.position, swordSwingPoint.firePoint.rotation);
            swordSwing.GetComponent<Rigidbody2D>().AddForce(swordSwingPoint.firePoint.up * shockwaveSpeed, ForceMode2D.Impulse);
            {
                yield return new WaitForSeconds(50f);
                isUsingSword = false;
            }
        }
    }
    
    public IEnumerator InvincibleAF()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        {
            isUsingRing = true;
            spriteRend.color = new Color(1, 1, 1, .5f);
            yield return new WaitForSeconds(5);
            Physics2D.IgnoreLayerCollision(6, 7, false);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(60f);
            isUsingRing = false;
        }
       
    }

    public IEnumerator Angery()
    {
        isUsingRage = true;
        spriteRend.color = new Color(1, 0, 0, 1);
        damageAdjust.bulletDamage = 50f;
        yield return new WaitForSeconds(8f);
        spriteRend.color = Color.white;
        damageAdjust.bulletDamage = 15f;
        yield return new WaitForSeconds(120f);
        isUsingRage = false;
    }
}
