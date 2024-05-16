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
    bool oneTime;


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
        oneTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 9 && haveBlueKey == false && WeaponManager.Instance.canGun == false) { blueKey.SetActive(true); gun.SetActive(true); }
        if (enemyCount == 11 && oneTime == true) { oneTime = false; Animator door = doorsCol[6].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 11) { Animator door = doorsCol[5].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 20 && haveYellowKey == false && WeaponManager.Instance.canBomber == false) 
        {
            yellowKey.SetActive(true); bomb.SetActive(true);
            Animator door = doorsCol[6].gameObject.GetComponent<Animator>(); door.SetBool("Open", true);
            oneTime = true;
        }
        if (enemyCount == 23) { Animator door = doorsCol[8].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 23) { Animator door = doorsCol[7].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 23 && oneTime == true) { oneTime = false; Animator door = doorsCol[9].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 32 && haveRedKey == false && WeaponManager.Instance.canArm == false) { redKey.SetActive(true); arm.SetActive(true); }
        if (enemyCount == 32) { Animator door = doorsCol[9].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 33) { Animator door = doorsCol[0].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 33) { Animator door = doorsCol[1].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); } 
        if (enemyCount == 33) { Animator door = doorsCol[2].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
        if (enemyCount == 37 && oneTime == true) { oneTime = false; Animator door = doorsCol[3].gameObject.GetComponent<Animator>(); door.SetBool("Open", true); }
    }

    
    public void SumEnemy()
    {
        nEnemies++;
    }
}
