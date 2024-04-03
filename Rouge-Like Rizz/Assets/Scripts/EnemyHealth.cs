using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
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
