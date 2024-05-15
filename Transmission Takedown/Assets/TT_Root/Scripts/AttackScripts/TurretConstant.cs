using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConstant : MonoBehaviour
{

    [Header("Attack Configuration")]
    public float timeBetweenAttacks; // Tiempo de espera entre ataque y ataque
    bool alreadyAttacked; // Bool para determinar si se ha atacado
    public bool canAttack;
    [SerializeField] GameObject projectile; // Ref al prefab del proyectil
    [SerializeField] Transform shootPoint; // Ref a la posición desde donde se disparan los proyectiles
    [SerializeField] float shootSpeedZ; // Vel. de disparo hacia delante
    [SerializeField] float shootSpeedY; // Vel. de disparo hacia arriba (en caso de bolea)
    Animator turretAnim;

    // Start is called before the first frame update
    void Start()
    {
        turretAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack == true)
        {

            turretAnim.SetBool("Fire", true);
            // Si no hemos atacado ya, atacamos
            Invoke(nameof(StopAttack), 2f);

        }
    }


    void GenetateProjectile()
    {
        Rigidbody rb = Instantiate(projectile, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootSpeedZ, ForceMode.Impulse);
        // rb.AddForce(transform.up * shootSpeedY, ForceMode.Impulse);
    }

    void ResetAttack()
    {
        canAttack = true;

    }

    void StopAttack()
    {
        canAttack = false;
        turretAnim.SetBool("Fire", false);
        Invoke(nameof(ResetAttack), timeBetweenAttacks); // Resetea el ataque con un intervalo
    }
}
