using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    [Header("Attack Stats")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;
    [SerializeField] bool canShoot;
    [SerializeField] bool shooting;
    public float lowCD;
    public float fastSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting) { Attacks(); }
    }

    void Attacks()
    {
        switch(WeaponManager.Instance.actualWeapon) 
        {
            case WeaponManager.Weapons.gun:
                if (canShoot)
                {
                    canShoot = false;
                    Rigidbody rb = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * fastSpeed, ForceMode.Impulse);
                    Invoke(nameof(ResetShoot), lowCD);
                }
                break;
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Dispara");
            shooting = true;

        }
        if (context.canceled)
        {
            shooting = false;
        }
    }

}
