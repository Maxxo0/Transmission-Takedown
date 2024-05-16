using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField] int attackDamage;
    [SerializeField] bool Sword;

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
            if (Sword)
            {
                WeaponManager.Instance.actualAmmo += 100;
            }
        }
        if (other.gameObject.CompareTag("Box"))
        {
            VoxHealth voxHealth = other.gameObject.GetComponent<VoxHealth>();
            voxHealth.BoxTakeDamage(attackDamage);
            if (Sword) 
            {
                WeaponManager.Instance.actualAmmo += 200;
            }
        }
        if (other.gameObject.CompareTag("Antena"))
        {
            TowerHealth towerHealth = other.gameObject.GetComponent<TowerHealth>();
            towerHealth.EnemyTakeDamage(attackDamage);
            if (Sword)
            {
                WeaponManager.Instance.actualAmmo += 100;
            }
        }

    }
}
