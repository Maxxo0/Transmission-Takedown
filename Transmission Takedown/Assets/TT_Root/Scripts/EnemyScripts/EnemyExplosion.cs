using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    [SerializeField] int enemyDamage;


    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(PowerOff), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();
            healthSystem.TakeDamage(enemyDamage);

        }
    }
    void PowerOff()
    {
        Destroy(gameObject);
    }
}
