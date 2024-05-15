using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrones : MonoBehaviour
{

    [SerializeField] GameObject dron;


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
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            dron.SetActive(true);
        }
    }


}
