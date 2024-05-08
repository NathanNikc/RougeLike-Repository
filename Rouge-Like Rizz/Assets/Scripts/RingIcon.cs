using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingIcon : MonoBehaviour
{
    private PowerupManager powerupManager;
    static SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        powerupManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PowerupManager>();
        spriteRend = GetComponent<SpriteRenderer>();
        if (powerupManager.hasRingPublic == true)
        {
            spriteRend.color = Color.white;
        }
        else if (powerupManager.hasRingPublic == false)
        {
            spriteRend.color = new Color(0, 0, 0, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (powerupManager.hasRingPublic == true)
        {
            spriteRend.color = Color.white;
        }
        else if (powerupManager.hasRingPublic == false) 
        {
            spriteRend.color = new Color(0, 0, 0, 0);
        }
    }
}
