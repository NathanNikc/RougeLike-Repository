using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyOOB : MonoBehaviour
{
    private float xBounds = 9.35f;
    private float yBounds = 4.4f;
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
