using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] int attackDamage;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.EnemyTakeDamage(attackDamage);
            
        }
        if (other.gameObject.CompareTag("Antena"))
        {
            TowerHealth towerHealth = other.gameObject.GetComponent<TowerHealth>();
            towerHealth.EnemyTakeDamage(attackDamage);
        }

    }
}
