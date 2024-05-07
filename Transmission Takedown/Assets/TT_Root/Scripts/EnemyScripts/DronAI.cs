using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAI : MonoBehaviour
{

    [SerializeField] Transform[] points;
    [SerializeField] int i;
    [SerializeField] float speed;

    Rigidbody dronRb;


    // Start is called before the first frame update
    void Start()
    {
        dronRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
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
}
