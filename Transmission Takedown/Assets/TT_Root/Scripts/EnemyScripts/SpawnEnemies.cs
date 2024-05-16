using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    [SerializeField] GameObject[] enemies;
    public int i;
    [SerializeField] float xPos;
    [SerializeField] float zPos;
    public int waveCount;
    public int wave;
    [SerializeField] GameObject nextSpawn;
    [SerializeField] int spawnRange;
    int enemiesSpawned;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framea
    void Update()
    {
        if (i == enemies.Length)
        {
            NextSpawn();
        }
        else
        {
            Spawn();
        }
    }


    void Spawn()
    {
        xPos = Random.Range(-spawnRange, spawnRange);
        zPos = Random.Range(-spawnRange, spawnRange);
        Instantiate(enemies[i], new Vector3(xPos + gameObject.transform.position.x, 0, gameObject.transform.position.z + zPos), Quaternion.identity);
        i++;
        SpawnManager.Instance.nEnemies++;

    }

    void NextSpawn()
    {
        if (SpawnManager.Instance.enemyCount == SpawnManager.Instance.nEnemies)
        {
            SpawnManager.Instance.spawnLimit += enemies.Length;
            nextSpawn.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
