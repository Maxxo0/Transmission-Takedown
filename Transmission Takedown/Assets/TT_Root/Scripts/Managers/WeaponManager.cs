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
    }


    public enum Weapons { gun, bomber, bigarm, car }

    [SerializeField] GameObject gunG, bombG, armG, carG;


    public Weapons actualWeapon;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnGun(InputAction.CallbackContext context)
    {
        gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
        actualWeapon = Weapons.gun;
    }
    public void OnBomber(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(true); armG.SetActive(false); carG.SetActive(false);
        actualWeapon = Weapons.bomber;
    }

    public void OnBigArm(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(true); carG.SetActive(false);
        actualWeapon = Weapons.bigarm;
    }

    public void OnCar(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(true);
        actualWeapon = Weapons.car;
    }
}
