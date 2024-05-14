using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapons : MonoBehaviour
{

    [SerializeField] bool isGun;
    [SerializeField] bool isBomber;
    [SerializeField] bool isBigArm;
    [SerializeField] bool isCar;



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
        if (other.gameObject.CompareTag("Player"))
        {
            if (isGun == true) { WeaponManager.Instance.canGun = true; PowerOff(); }
            if (isBomber == true) { WeaponManager.Instance.canBomber = true; PowerOff(); }
            if (isBigArm == true) { WeaponManager.Instance.canArm = true; PowerOff(); }
            if (isCar == true) { WeaponManager.Instance.canCar = true; PowerOff(); }

        }
    }

    void PowerOff()
    {
        gameObject.SetActive(false);
    }

}
