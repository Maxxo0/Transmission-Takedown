using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    [SerializeField] bool blue, yellow, red;
    [SerializeField] GameObject doors;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (blue == true && SpawnManager.Instance.haveBlueKey == true) { Animator door = doors.gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
            if (yellow == true && SpawnManager.Instance.haveYellowKey == true) { Animator door = doors.gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
            if (red == true && SpawnManager.Instance.haveRedKey == true) { Animator door = doors.gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        }
    }
}
