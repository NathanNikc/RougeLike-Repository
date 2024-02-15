using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos; //create a new vector3 variable to hold the position that the wall will start at
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //assign the start position variable to the possition the object is at at the start of the game
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //set the distance the object has to travel before it repeats to half the length of the background. The background has its design repeated halfway through, so this will make it look like on smooth, constant background
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) //if the position of the object on the x is less than the start position of the object when the game starts - a certain distance to account for the length of the object so the object doesnt repeat only when the object has fully reached the x boundary
        {
            transform.position = startPos; //set the position of the object back to where it was at the start
        }
    }
}
