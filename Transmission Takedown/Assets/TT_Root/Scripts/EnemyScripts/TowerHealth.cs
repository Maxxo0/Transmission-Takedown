using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [Header("Enemy Life Stats")]
    public float enemyHealth;
    public float enemyMaxHealth;
    public bool canDie;
    Animator antenaAnimator;
    [SerializeField] int enemiesForDie;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        antenaAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canDie == false) { enemyHealth = enemyMaxHealth; }
        if (enemyHealth <= 0) { enemyHealth = 0; EnemyDie(); }
        if (SpawnManager.Instance.enemyCount == enemiesForDie) { canDie = true; antenaAnimator.SetBool("VDown", true); }
        //if (SpawnManager.Instance.nEnemies == FirstZoneManager.Instance.maxEnemies) { canDie = true; }
    }


    public void EnemyTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;

    }

    void EnemyDie()
    {
        SpawnManager.Instance.enemyCount++;
        Debug.Log("Enemigo Ejecutado");
        antenaAnimator.SetBool("ADown", true);
        
    }
}
