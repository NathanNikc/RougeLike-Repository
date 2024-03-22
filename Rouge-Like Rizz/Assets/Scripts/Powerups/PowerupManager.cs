 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;
    public bool hasRing = false;
    public bool isUsingRing = false;
    public bool hasRage = false;
    public bool isUsingRage = false;
    [SerializeField] private BulletDamage damageAdjust;

    // Start is called before the first frame update
    public void Start()
    {
        spriteRend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        damageAdjust = GameObject.FindGameObjectWithTag("Bullet").GetComponent<BulletDamage>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && hasRing == true && isUsingRing == false)
        {
            StartCoroutine(InvincibleAF());
        }

        if (Input.GetKeyDown(KeyCode.X) && hasRage == true && isUsingRage == false)
        {
            damageAdjust.bulletDamage = 50f;
            StartCoroutine(Angery());
            damageAdjust.bulletDamage = 15f;
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
            yield return new WaitForSeconds(5f);
            isUsingRing = false;
        }
       
    }

    public IEnumerator Angery()
    {
        isUsingRage = true;
        spriteRend.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(3);
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(5);
        isUsingRage = false;
    }
}
