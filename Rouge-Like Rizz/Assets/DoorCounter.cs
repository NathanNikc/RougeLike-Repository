using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCounter : MonoBehaviour
{
    static int doorsEntered = 0;
    public int doorsEnteredPublic;
    
    // Start is called before the first frame update
    void Start()
    {
        doorsEnteredPublic = doorsEntered;
    }

    // Update is called once per frame
    void Update()
    {
        doorsEnteredPublic = doorsEntered;
    }

    public void DoorAddOne(int doorEntered)
    {
        doorsEntered += 1;
    }
}
