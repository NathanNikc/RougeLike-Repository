using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>(); 
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void SetHealth(int health)
    {
        slider.value = health;
    }
}
