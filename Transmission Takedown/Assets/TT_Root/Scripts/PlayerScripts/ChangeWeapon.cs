using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{


    [SerializeField] GameObject gunG, bombG, armG, carG;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGun(InputAction.CallbackContext context)
    {
        gunG.SetActive(true); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(false);
    }
    public void OnBomber(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(true); armG.SetActive(false); carG.SetActive(false);
    }

    public void OnBigArm(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(true); carG.SetActive(false);
    }

    public void OnCar(InputAction.CallbackContext context)
    {
        gunG.SetActive(false); bombG.SetActive(false); armG.SetActive(false); carG.SetActive(true);
    }
}
