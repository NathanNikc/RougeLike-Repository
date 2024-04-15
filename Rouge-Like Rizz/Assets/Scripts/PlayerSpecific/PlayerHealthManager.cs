using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    public GameObject healthPot;

    public Image healthBar;
    static float healthAmount = 1000f;
    private float healthMax = 1000f;
    private GameObject player;
    public bool hasHeal = false;
    public int healCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.fillAmount = healthAmount / healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        HealMeathods();
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthMax); //makes sure the value of "healthAmount" can't be less than 0 or greater than 100;

        healthBar.fillAmount = healthAmount / healthMax;
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / healthMax;
    }

    public void PickUpPot()
    {
        healCounter += 1;
    }

    //holds almost-everything to do with healing
    public void HealMeathods()
    {
        //spawn in health pot
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(healthPot);
        }

        if (healCounter > 0)
        {
            hasHeal = true;
        }
        else if (healCounter <= 0)
        {
            hasHeal = false;
        }

        if (healthAmount <= 0)
        {
            Destroy(player);
        }

        if (Input.GetKeyDown(KeyCode.Q) && hasHeal == true && healthAmount < healthMax)
        {
            Heal(20);
            healCounter -= 1;
            Debug.Log("You have " + healCounter + " heals!");
        }
    }
}
