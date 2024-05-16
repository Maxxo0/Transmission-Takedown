using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] GameObject doorToClose;


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
            Animator door = doorToClose.gameObject.GetComponent<Animator>(); door.SetBool("Open", false);
            gameObject.SetActive(false);
        }
    }
}
