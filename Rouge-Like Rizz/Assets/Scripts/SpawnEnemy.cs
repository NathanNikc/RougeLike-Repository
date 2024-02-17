using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject pickaxeEnemy;

    public EnemyHealthManager setEnemy;

    // Start is called before the first frame update
    void Start()
    {
        setEnemy = GameObject.FindGameObjectWithTag("DamageTaker").GetComponent<EnemyHealthManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(pickaxeEnemy);
        }
    }
}
