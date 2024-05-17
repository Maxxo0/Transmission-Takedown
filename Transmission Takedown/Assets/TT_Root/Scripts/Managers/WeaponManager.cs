using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    [SerializeField] GameObject gunG, bombG, armG, carG, handG, swordG;
    [SerializeField] GameObject cgun, cbomb, carm, ccar;
    public Weapons actualWeapon;
    public bool canGun, canBomber, canArm, canCar, onCar, haveMaxAmmo, canSword;
    public bool firstSword, firstGun, firstBomber, firstBigArm;
    public float maxAmmo;
    public float actualAmmo;
    [SerializeField] Image ammoBar;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoBar.fillAmount = actualAmmo / maxAmmo;

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
        else { haveMaxAmmo = false; }
        
        if (canSword == true) { swordG.SetActive(true); }
    }

    public void OnGun(InputAction.CallbackContext context)
    {
        if (canGun && onCar == false) 
        {
            gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
            cgun.SetActive(true); cbomb.SetActive(false); carm.SetActive(false); ccar.SetActive(false);
            actualWeapon = Weapons.gun;
        }
    }
    public void OnBomber(InputAction.CallbackContext context)
    {
        if (canBomber && onCar == false) 
        {
            gunG.SetActive(false); bombG.SetActive(true); armG.SetActive(false); carG.SetActive(false);
            cgun.SetActive(false); cbomb.SetActive(true); carm.SetActive(false); ccar.SetActive(false);
            actualWeapon = Weapons.bomber;
        }
    }

    public void OnBigArm(InputAction.CallbackContext context)
    {
        if (canArm && onCar == false) 
        {
            gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(true); carG.SetActive(false);
            cgun.SetActive(false); cbomb.SetActive(false); carm.SetActive(true); ccar.SetActive(false);
            actualWeapon = Weapons.bigarm;
        }
    }

    public void OnCar(InputAction.CallbackContext context)
    {
        if (canCar && haveMaxAmmo)
        {
            haveMaxAmmo = false;
            carG.SetActive(true);
            cgun.SetActive(false); cbomb.SetActive(false); carm.SetActive(false); ccar.SetActive(true);
            actualWeapon = Weapons.car;
        }
        else if (canGun)
        {
            gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
            cgun.SetActive(true); cbomb.SetActive(false); carm.SetActive(false); ccar.SetActive(false);
            actualWeapon = Weapons.gun;
        }
    }

    public void OffCar()
    {
        gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
        actualWeapon = Weapons.gun;
    }
}
