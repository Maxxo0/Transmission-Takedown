using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] GameObject[] doorsCol;
    [SerializeField] GameObject blueKey, yellowKey, redKey;
    [SerializeField] GameObject gun, bomb, arm, car;
    public bool haveBlueKey, haveYellowKey, haveRedKey;



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
        if (enemyCount == 9 && haveBlueKey == false && WeaponManager.Instance.canGun == false) { blueKey.SetActive(true); gun.SetActive(true); }
        if (enemyCount == 11) { Animator door = doorsCol[0].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 20 && haveYellowKey == false && WeaponManager.Instance.canBomber == false) { yellowKey.SetActive(true); bomb.SetActive(true); }
    }

    
    public void SumEnemy()
    {
        nEnemies++;
    }
}
