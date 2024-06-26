using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RizzOMeter : MonoBehaviour
{
    public Image rizz;
    static float rizzAmount = 5000;
    private float rizzMax = 100000f;
    public float shareRizzAmount = rizzAmount;

    // Start is called before the first frame update
    void Start()
    {
        rizz.fillAmount = rizzAmount / rizzMax;
    }

    // Update is called once per frame
    void Update()
    {
        RizzMeathods();
        shareRizzAmount = rizzAmount;
    }

    public void GainRizz(float gainRizzAmount)
    {
        rizzAmount += gainRizzAmount;
        rizzAmount = Mathf.Clamp(rizzAmount, 0, rizzMax); //makes sure the value of "healthAmount" can't be less than 0 or greater than 100;

        rizz.fillAmount = rizzAmount / rizzMax;
    }
    public void LoseRizz(float fumble)
    {
        rizzAmount -= fumble;
        rizz.fillAmount = rizzAmount / rizzMax;
    }

    //holds almost-everything to do with healing
    public void RizzMeathods()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GainRizz(1000f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            LoseRizz(500f);
        }

        if (rizzAmount <= 0)
        {
            HeartbreakEnding();
            rizzAmount = 5000;
        }
    }

    public void HeartbreakEnding()
    {
        SceneManager.LoadScene(27, LoadSceneMode.Single);
    }
}
