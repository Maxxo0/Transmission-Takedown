using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [Header("Life Stats")]
    [SerializeField] Image hpBar;
    public float health;
    public float maxHealth;
    public Transform spawnpoint;
    bool alive;
    Animator playerAnim;
    


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        alive = true;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && alive == true) { alive = false; health = 0; playerAnim.SetTrigger("Die"); WeaponManager.Instance.canSword = false; }
        if (health >= maxHealth) { health = maxHealth; }
        hpBar.fillAmount = health / maxHealth;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

    }



    void Die()
    {
        Debug.Log("Moriste");

        health = maxHealth;
        alive = true;
        transform.position = spawnpoint.position;
        WeaponManager.Instance.canSword = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnPoint"))
        {
            spawnpoint = other.gameObject.transform;
        }
    }

}
