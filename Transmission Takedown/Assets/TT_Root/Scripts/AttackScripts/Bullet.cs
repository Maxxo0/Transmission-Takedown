using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] int bulletDamage;

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
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.EnemyTakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.EnemyTakeDamage(bulletDamage);
            Destroy(gameObject);
            Debug.Log("Pega");
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Debug.Log("Pega");
        }
    }
}
