using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    [SerializeField] bool blue, yellow, red;


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
            if (blue == true)
            {
                SpawnManager.Instance.haveBlueKey = true; gameObject.SetActive(false);
            }
            if (red == true) { SpawnManager.Instance.haveRedKey = true; gameObject.SetActive(false);}
            if (yellow == true) { SpawnManager.Instance.haveYellowKey = true; gameObject.SetActive(false);}
        }
    }
}
