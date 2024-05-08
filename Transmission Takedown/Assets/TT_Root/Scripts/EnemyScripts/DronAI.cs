using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAI : MonoBehaviour
{

    [SerializeField] Transform[] points;
    [SerializeField] Transform enemyBoomShootPoint;
    [SerializeField] int i;
    [SerializeField] float speed;
    [SerializeField] GameObject enemyBomb;
    [SerializeField] bool canThrow;
    [SerializeField] bool canMove;

    Rigidbody dronRb;


    // Start is called before the first frame update
    void Start()
    {
        dronRb = GetComponent<Rigidbody>();
        canMove = true;
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) { Move(); }
        if (transform.position == points[i].position)
        {
            if (canThrow) { DronAttack(); }
        }
    }

    void Move()
    {
        if (transform.position == points[i].position)
        {
            i++; //sumar 1 al indice.Al cambiar el indice,cambia el objetivo a seguir
            if (i == points.Length) //chequea si el valor de i es igual a la longitud del Array
            {
                i = 0; // si lo es, el indice pasa a ser  0 para repetir la ruta

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }


    void DronAttack()
    {
        canMove = false;
        canThrow = false;
        Rigidbody rb = Instantiate(enemyBomb, enemyBoomShootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        Invoke(nameof(ResetMove), 1f);
        Invoke(nameof(ResetAttack), 2f);
    }

    void ResetAttack()
    {
        canThrow = true;
    }

    void ResetMove()
    {
        canMove= true;
    }
}
