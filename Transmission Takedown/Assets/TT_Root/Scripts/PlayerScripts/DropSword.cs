using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSword : MonoBehaviour
{

    [SerializeField] GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Drop()
    {
        sword.gameObject.AddComponent<Rigidbody>();
       
    }
}
