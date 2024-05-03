using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotCounter : MonoBehaviour
{
    public static int healthPotAmount = 0;
    TextMeshProUGUI amount;
    private PlayerHealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        amount = GetComponent<TextMeshProUGUI>();
        healthManager = GameObject.FindGameObjectWithTag("Healer").GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = "x" + healthManager.healCounterPublic;
    }
}
