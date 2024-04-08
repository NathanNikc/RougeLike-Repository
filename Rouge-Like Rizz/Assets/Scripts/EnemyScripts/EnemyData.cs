using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjectenemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;
}
