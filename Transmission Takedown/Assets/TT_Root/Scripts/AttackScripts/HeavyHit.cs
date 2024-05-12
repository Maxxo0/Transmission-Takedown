using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyHit : MonoBehaviour
{

    [SerializeField] int heavyDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
            healthSystem.TakeDamage(heavyDamage);
            
        }
    }


}
