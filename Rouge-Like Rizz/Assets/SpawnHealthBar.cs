using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthBar : MonoBehaviour
{
    [SerializeField] public GameObject HealthBarPrefab;
    [SerializeField] public Transform HealthBarSpawnPoint;
    [SerializeField] public GameObject HealthBar;
    private EnemyHealthManager SetHealthBarParent;

    public void Start()
    {
        HealthBar = Instantiate(HealthBarPrefab, HealthBarSpawnPoint.position, HealthBarSpawnPoint.rotation);
        SetHealthBarParent = GetComponent<EnemyHealthManager>();
    }



    public void Update()
    {
        SetHealthBarParent = GetComponent<EnemyHealthManager>();
        SetHealthBarParent.enemy = gameObject;
    }
}
