using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if the player presses the spacebar
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation); //spawn an instance of the wine object, in the position the object is in the prefab, at the rotation the prefab is set
        }
    }
}
