using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudRizzAmount : MonoBehaviour
{
    TextMeshProUGUI amount;
    private RizzOMeter rizzAmountFinder;

    // Start is called before the first frame update
    void Start()
    {
        amount = GetComponent<TextMeshProUGUI>();
        rizzAmountFinder = GameObject.FindGameObjectWithTag("RizzMeter").GetComponent<RizzOMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = rizzAmountFinder.shareRizzAmount + " Rizz Points";
    }
}
