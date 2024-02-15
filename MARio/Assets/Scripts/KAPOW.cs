using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAPOW : MonoBehaviour
{

    public Rigidbody obstacleRb;
    // Start is called before the first frame update
    void Start()
    {
       obstacleRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obstacleRb.AddForce(Vector3.right * 500);
        }
    
    }
}
