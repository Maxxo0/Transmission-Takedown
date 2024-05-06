using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Life Stats")]
    public float enemyHealth;
    public float enemyMaxHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) { enemyHealth = 0; EnemyDie(); }
    }


    public void EnemyTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;

    }

    void EnemyDie()
    {
        Debug.Log("Enemigo Ejecutado");
    }
}
