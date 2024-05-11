using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DronAI : MonoBehaviour
{

    [SerializeField] Transform[] points;
    [SerializeField] Transform enemyBoomShootPoint;
    [SerializeField] int i;
    [SerializeField] float speed;
    [SerializeField] GameObject enemyBomb;
    [SerializeField] bool canThrow;
    [SerializeField] bool canMove;
    [SerializeField] GameObject torret;
    Animator dronAnimator;

    Rigidbody dronRb;


    // Start is called before the first frame update
    void Start()
    {

        dronRb = GetComponent<Rigidbody>();
        dronAnimator = GetComponent<Animator>();
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
        transform.LookAt(points[i]);

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }


    void DronAttack()
    {
        dronAnimator.SetTrigger("Attack");
        canMove = false;
        canThrow = false;
        
    }

    void DronThrow()
    {
        Rigidbody rb = Instantiate(enemyBomb, enemyBoomShootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
    }

    void ResetAttack()
    {
        canThrow = true;
    }

    void ResetMove()
    {
        canMove= true;
        Invoke(nameof(ResetAttack), 2f);
    }
}
