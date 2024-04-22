using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambioArmaProb : MonoBehaviour
{

    [Header("Armas")]
    [SerializeField] GameObject pistola;
    [SerializeField] GameObject moha;
    [SerializeField] GameObject brazoF;
    [SerializeField] GameObject coche;

    [Header("Iconos Armas")]
    [SerializeField] GameObject iPistola;
    [SerializeField] GameObject iMoha;
    [SerializeField] GameObject iBrazoF;
    [SerializeField] GameObject iCoche;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    public void ChangeWeapon1(InputAction.CallbackContext context)
    {
        pistola.SetActive(true);
        moha.SetActive(false);
        brazoF.SetActive(false);
        coche.SetActive(false);

        iPistola.SetActive(true);
        iMoha.SetActive(false);
        iBrazoF.SetActive(false);
        iCoche.SetActive(false);
    }

    public void ChangeWeapon2(InputAction.CallbackContext context)
    {
        pistola.SetActive(false);
        moha.SetActive(true);
        brazoF.SetActive(false);
        coche.SetActive(false);

        iPistola.SetActive(false);
        iMoha.SetActive(true);
        iBrazoF.SetActive(false);
        iCoche.SetActive(false);
    }
    public void ChangeWeapon3(InputAction.CallbackContext context)
    {
        pistola.SetActive(false);
        moha.SetActive(false);
        brazoF.SetActive(true);
        coche.SetActive(false);

        iPistola.SetActive(false);
        iMoha.SetActive(false);
        iBrazoF.SetActive(true);
        iCoche.SetActive(false);
    }

    public void ChangeWeapon4(InputAction.CallbackContext context)
    {
        pistola.SetActive(false);
        moha.SetActive(false);
        brazoF.SetActive(false);
        coche.SetActive(true);

        iPistola.SetActive(false);
        iMoha.SetActive(false);
        iBrazoF.SetActive(false);
        iCoche.SetActive(true);
    }


}
