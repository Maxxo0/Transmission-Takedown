using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenaSpawn : MonoBehaviour
{
    [SerializeField] GameObject antena;


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
            Animator antenaAnim = antena.GetComponent<Animator>();
            antenaAnim.SetBool("Up", true);
        }
    }

}
