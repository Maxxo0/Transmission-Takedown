using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance;
    public static WeaponManager Instance
    {
        get
        {
            if (instance == null)
            {

                Debug.Log("WeaponManager is null!");
            }
            return instance;
        }
    }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        actualAmmo = maxAmmo;
    }



    public enum Weapons { gun, bomber, bigarm, car, hand }
    [SerializeField] GameObject gunG, bombG, armG, carG, handG;
    public Weapons actualWeapon;
    public bool canGun, canBomber, canArm, canCar, onCar, haveMaxAmmo;
    public float maxAmmo;
    public float actualAmmo;



    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actualWeapon == Weapons.hand) 
        {
            handG.gameObject.SetActive(true);
            gunG.gameObject.SetActive(false);
            bombG.gameObject.SetActive(false);
            armG.gameObject.SetActive(false);
            carG.gameObject.SetActive(false);
        }
        else
        {
            handG.gameObject.SetActive(false);
        }
        
        if (actualAmmo <= 0) { actualAmmo = 0; }
        if (actualAmmo > maxAmmo) { actualAmmo = maxAmmo; }
        if (actualAmmo == maxAmmo)
        {
            haveMaxAmmo = true;
        }
        

    }

    public void OnGun(InputAction.CallbackContext context)
    {
        if (canGun && onCar == false) 
        {
            gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
            actualWeapon = Weapons.gun;
        }
    }
    public void OnBomber(InputAction.CallbackContext context)
    {
        if (canBomber && onCar == false) 
        {
            gunG.SetActive(false); bombG.SetActive(true); armG.SetActive(false); carG.SetActive(false);
            actualWeapon = Weapons.bomber;
        }
    }

    public void OnBigArm(InputAction.CallbackContext context)
    {
        if (canArm && onCar == false) 
        {
            gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(true); carG.SetActive(false);
            actualWeapon = Weapons.bigarm;
        }
    }

    public void OnCar(InputAction.CallbackContext context)
    {
        if (canCar && haveMaxAmmo)
        {
            carG.SetActive(true);
            actualWeapon = Weapons.car;
        }
        else
        {
            gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
            actualWeapon = Weapons.gun;
        }
    }

    public void OffCar()
    {
        gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
        actualWeapon = Weapons.gun;
    }
}
