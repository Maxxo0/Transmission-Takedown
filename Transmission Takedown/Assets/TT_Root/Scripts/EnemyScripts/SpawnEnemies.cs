using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] spawnPoints;
    public int waveCount;
    public int wave;
    public int enemyType;
    public bool spawning;
    int enemiesSpawned;


    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
    }

    // Update is called once per frame
    void Update()
    {
         
    }


    void Spawn()
    {
        
    }
}
