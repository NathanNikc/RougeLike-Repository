using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShockwaveOOB : MonoBehaviour
{
    private float xBounds = 20f;
    private float yBounds = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > xBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > yBounds)
        {
            Destroy(gameObject);
        }
    }
}
