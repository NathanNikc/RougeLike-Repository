using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    public GameObject healthPot;

    public Image healthBar;
    public float healthAmount = 100f;
    public GameObject player;
    public bool hasHeal = false;
    public int healCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealMeathods();

        //placeholder for player getting hurt
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TakeDamage(15f);
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); //makes sure the value of "healthAmount" can't be less than 0 or greater than 100;

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
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


        Debug.Log("You have " + healCounter + " heals!");

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

        if (Input.GetKeyDown(KeyCode.C) && hasHeal == true && healthAmount < 100f)
        {
            Heal(20);
            healCounter -= 1;
            Debug.Log("You have " + healCounter + " heals!");
        }
    }
}
