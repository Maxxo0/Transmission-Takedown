using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretOneHIt2 : MonoBehaviour
{
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
        if (TurretManager.Instance.secondTurret == true)
        {

            turretAnim.SetTrigger("Fire");

        }

    }

    void GenetateProjectile()
    {
        TurretManager.Instance.secondTurret = false;
        Rigidbody rb = Instantiate(projectile, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootSpeedZ, ForceMode.Impulse);
        Invoke(nameof(ActiveFirstTurret), TurretManager.Instance.turretTime);
        // rb.AddForce(transform.up * shootSpeedY, ForceMode.Impulse);
    }

    void ActiveFirstTurret()
    {
        TurretManager.Instance.firstTurret = true;
    }
}
