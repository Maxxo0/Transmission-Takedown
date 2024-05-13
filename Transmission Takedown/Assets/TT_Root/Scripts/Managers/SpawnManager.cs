using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private static SpawnManager instance;

    public static SpawnManager Instance
    {
        get { return instance; }
    }

    public int maxEnemies;
    public int nEnemies;
    public int enemyCount;
    public int spawnLimit;

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







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SumEnemy()
    {
        nEnemies++;
    }
}
