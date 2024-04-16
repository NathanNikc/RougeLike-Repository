using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SammichCooldownTimer : MonoBehaviour
{
    TextMeshProUGUI amount;
    private float timeValue = 120;

    // Start is called before the first frame update
    void Start()
    {
        amount = GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        timeValue -= Time.deltaTime;
        amount.text = timeValue.ToString();
    }
}
