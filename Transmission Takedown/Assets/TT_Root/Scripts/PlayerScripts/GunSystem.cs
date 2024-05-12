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
    [SerializeField] bool canAttack;
    
    
    [SerializeField] bool shooting;
    
    [SerializeField] float lowCD;
    [SerializeField] float highCD;
    [SerializeField] float midCD;
    [SerializeField] float carCD;
    [SerializeField] bool shootingCar;
    [SerializeField] float fastSpeed;
    [SerializeField] float slowSpeed;
    PlayerController playerController;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting) { Attacks(); }
        if (WeaponManager.Instance.actualWeapon == WeaponManager.Weapons.car) { shooting = true; }
        if (shootingCar) { WeaponManager.Instance.actualAmmo -= 1; }
        if (shootingCar && WeaponManager.Instance.actualAmmo <= 0) { Invoke(nameof(StopCar), 0f);  }
        
    }

    void Attacks()
    {
        switch(WeaponManager.Instance.actualWeapon) 
        {
            case WeaponManager.Weapons.gun:
                if (canShoot && canAttack && WeaponManager.Instance.actualAmmo >= 100)
                {
                    canShoot = false;
                    WeaponManager.Instance.actualAmmo -= 100;
                    playerAnimator.SetTrigger("GunAttack");
                    playerController.StopMove();
                    Rigidbody rb = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * fastSpeed, ForceMode.Impulse);
                    Invoke(nameof(ResetShoot), lowCD);
                }
                break;
            case WeaponManager.Weapons.bomber:
                if (canShoot && canAttack && WeaponManager.Instance.actualAmmo >= 200)
                {
                    canShoot = false;
                    playerAnimator.SetTrigger("BomberAttack");
                    WeaponManager.Instance.actualAmmo -= 200;
                    playerController.StopMove();
                    Rigidbody rb = Instantiate(bomb, shootPointB.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * slowSpeed, ForceMode.Impulse);
                    rb.AddForce(transform.up * fastSpeed, ForceMode.Impulse);
                    Invoke(nameof(ResetShoot), midCD);
                }
                break;
            case WeaponManager.Weapons.bigarm:
                if (canShoot && canAttack && WeaponManager.Instance.actualAmmo >= 300)
                {
                    canShoot = false;
                    WeaponManager.Instance.actualAmmo -= 300;
                    playerController.StopMove();
                    playerAnimator.SetTrigger("BigArmAttack");
                    Invoke(nameof(ResetShoot), highCD);
                }
                break;
            case WeaponManager.Weapons.car:

                
                if (canShoot && canAttack && WeaponManager.Instance.actualAmmo >= 600)
                {
                    canShoot = false;
                    shootingCar = true;
                    WeaponManager.Instance.onCar = true;
                }
                break;
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    void StopCar()
    {

        Debug.Log("PAra");
        shootingCar = false; 
        shooting = false;
        canAttack = true;
        canShoot = true;
        WeaponManager.Instance.canCar = false;
        WeaponManager.Instance.onCar = false;
        WeaponManager.Instance.haveMaxAmmo = false;
        WeaponManager.Instance.OffCar();
        Invoke(nameof(CarCoolDown), carCD);
        
        
    }

    void CarCoolDown()
    {
        Debug.Log("Can Car Reset");
        WeaponManager.Instance.canCar = true;
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

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (canAttack ) 
            {
                canAttack = false;
                playerAnimator.SetTrigger("MeleeAttack");
                Invoke(nameof(ResetAttack), 0.5f);
            }  
        }
        if (context.canceled)
        {

        }
    }

   

}
