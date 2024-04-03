 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private BulletDamageManager damageAdjust;
    static bool hasRing = false;
    static bool isUsingRing = false;
    static bool hasRage = false;
    static bool isUsingRage = false;
    static bool hasBook = false;
    public float shootDelay = .5f;
 

    // Start is called before the first frame update
    public void Start()
    {
        spriteRend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        damageAdjust = GameObject.FindGameObjectWithTag("DamageManager").GetComponent<BulletDamageManager>();
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
