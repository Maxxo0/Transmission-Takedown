using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxHealth : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void BoxTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;
        
    }
}
