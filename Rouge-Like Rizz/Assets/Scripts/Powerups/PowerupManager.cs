 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;
    public bool hasRing = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && hasRing == true)
        {
            StartCoroutine(InvincibleAF());
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
    }

    public IEnumerator InvincibleAF()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        {
            spriteRend.color = new Color(1, 1, 1, .5f);
            yield return new WaitForSeconds(5);
            spriteRend.color = Color.white;
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        {
            //need to wait before player is able to use the ring again
        }
    }

}
