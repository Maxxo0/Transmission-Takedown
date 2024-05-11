using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Life Stats")]
    public float enemyHealth;
    public float enemyMaxHealth;
    bool canDie;
    public bool alive;
    Animator enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        
        enemyHealth = enemyMaxHealth;
        alive = true;
        canDie = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) 
        { 
            if (canDie == true) 
            {
                canDie = false;
                enemyHealth = 0; EnemyDie();
            } 
        }
    }


    public void EnemyTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;

    }

    void EnemyDie()
    {
        SpawnManager.Instance.RestEnemy();
        enemyAnimator.SetTrigger("Death");
        Debug.Log("Enemigo Ejecutado");
        
    }

    public void Death() { gameObject.SetActive(false); }
}
