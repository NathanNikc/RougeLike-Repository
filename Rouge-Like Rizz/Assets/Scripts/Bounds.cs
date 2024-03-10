using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private float topBound = 4.1f;
    private float bottomBound = -3.6f;
    private float leftBound = -7.8f;
    private float rightBound = 7.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftBound, rightBound), Mathf.Clamp(transform.position.y, bottomBound, topBound));
    }
}
