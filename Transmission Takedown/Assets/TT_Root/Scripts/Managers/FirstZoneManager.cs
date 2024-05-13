using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstZoneManager : MonoBehaviour
{
    private static FirstZoneManager instance;
    public static FirstZoneManager Instance
    {
        get
        {
            if (instance == null)
            {

                Debug.Log("FZManager is null!");
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

    private void Update()
    {
    
    }

    

    
}
