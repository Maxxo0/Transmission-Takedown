using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrets : MonoBehaviour
{
    [SerializeField] bool tC, t12;
    


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
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            if (tC == true) { TurretManager.Instance.turretCShoot = true; }
            if (t12 == true) { TurretManager.Instance.turret12Shoot = true; }
        }
    }
}
