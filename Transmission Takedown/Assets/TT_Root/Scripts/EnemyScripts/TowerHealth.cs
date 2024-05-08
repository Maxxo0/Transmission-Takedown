using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [Header("Enemy Life Stats")]
    public float enemyHealth;
    public float enemyMaxHealth;
    public bool canDie;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) { enemyHealth = 0; EnemyDie(); }
        if (FirstZoneManager.Instance.nEnemies == FirstZoneManager.Instance.maxEnemies) { canDie = true; }
    }


    public void EnemyTakeDamage(int playerDamage)
    {
        if (canDie) { enemyHealth -= playerDamage; }

    }

    void EnemyDie()
    {
        Debug.Log("Enemigo Ejecutado");
        gameObject.SetActive(false);
    }
}
