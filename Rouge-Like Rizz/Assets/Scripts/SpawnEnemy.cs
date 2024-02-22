using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject pickaxeEnemy;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(pickaxeEnemy);
        }
    }
}
