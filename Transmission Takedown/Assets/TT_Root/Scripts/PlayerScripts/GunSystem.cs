using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    [Header("Attack Stats")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject shootPointB;
    [SerializeField] bool canShoot;
    [SerializeField] bool shooting;
    
    public float lowCD;
    public float fastSpeed;
    public float slowSpeed;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
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
                    playerController.StopMove();
                    Rigidbody rb = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * fastSpeed, ForceMode.Impulse);
                    Invoke(nameof(ResetShoot), lowCD);
                }
                break;
            case WeaponManager.Weapons.bomber:
                if (canShoot)
                {
                    canShoot = false;
                    playerController.StopMove();
                    Rigidbody rb = Instantiate(bomb, shootPointB.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * slowSpeed, ForceMode.Impulse);
                    rb.AddForce(transform.up * fastSpeed, ForceMode.Impulse);
                    Invoke(nameof(ResetShoot), lowCD);
                }
                break;
            case WeaponManager.Weapons.bigarm:
                break;
            case WeaponManager.Weapons.car:


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
