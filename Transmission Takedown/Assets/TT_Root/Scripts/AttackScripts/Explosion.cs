using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int attackDamage;


    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(PowerOff), 1f);
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

    }

    void PowerOff()
    {
        Destroy(gameObject);
    }

}

