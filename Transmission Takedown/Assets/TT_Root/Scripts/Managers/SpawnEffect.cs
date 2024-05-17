using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
        Invoke(nameof(Chao), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Chao()
    {
        gameObject.SetActive(false);
    }
}
