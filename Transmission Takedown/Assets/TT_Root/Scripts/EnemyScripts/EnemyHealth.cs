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
    [SerializeField] bool isRanger;
    [SerializeField] int i;
    [SerializeField] GameObject dropHeal;
    Animator enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        
        enemyHealth = enemyMaxHealth;
        alive = true;
        canDie = true;
        i = Random.Range(1, 5);

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
        if (isRanger == true) 
        {
            RangerAI rangerAI = GetComponent<RangerAI>();
            rangerAI.canAttack = false;
            Invoke(nameof(ResetHit), 0.2f);
        }
    }

    void EnemyDie()
    {
        if (i == 1) { Instantiate(dropHeal, transform.position, Quaternion.identity); }
        SpawnManager.Instance.enemyCount++;
        enemyAnimator.SetTrigger("Death");
        Debug.Log("Enemigo Ejecutado");
        
    }

    void ResetHit()
    {
        RangerAI rangerAI = GetComponent<RangerAI> ();
        rangerAI.canAttack = true;
    }

    public void Death() { gameObject.SetActive(false); }
}
