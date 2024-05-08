using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    [Header("AI Conf")]
    [SerializeField] NavMeshAgent agent; // Ref al componente Agente, que permite que el objeto tenga IA
    [SerializeField] Transform target; // Ref al transform del objeto que la IA va a perseguir
    [SerializeField] LayerMask targetLayer; // Determina cual es la capa de deteccion del target
    [SerializeField] LayerMask groundLayer; // Determina cual es la capa de detección del suelo
    [SerializeField] float carSpeed;
    

    [Header("Attack Configuration")]
    public float timeBetweenAttacks; // Tiempo de espera entre ataque y ataque
    bool alreadyAttacked; // Bool para determinar si se ha atacado
    [SerializeField] GameObject carHitBox;

   
    [Header("States & Detection")]
    [SerializeField] float sightRange; // Rango de detección de persecución de la IA
    [SerializeField] float attackRange; // Rango a partir del cual la IA ataca
    [SerializeField] bool targetInSightRange; // Bool que determina si el target está a distancia de detección
    [SerializeField] bool targetInAttackRange; // Bool que determina si el target está a distancia de ataque

    private void Awake()
    {
        target = GameObject.Find("Player").transform; // Al inicio referencia el transform del Player, para poder perseguirlo cuando toca   
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Chequear si el target está en los rangos de detección y de ataque
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, targetLayer);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, targetLayer);

        // Si detecta el target pero no está em rango de ataque: PERSIGUE
        if (targetInSightRange && !targetInAttackRange) ChaseTarget();
        // Si detecta al target y está en rango de ataque: ATACA
        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }

    void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        // Cuando comienza a atacar, no se mueve (se persigue a si mismo)
        agent.SetDestination(transform.position);
        // La IA mira directamente al target
        transform.LookAt(target);

        if (!alreadyAttacked)
        {

            // Si no hemos atacado ya, atacamos
            carHitBox.SetActive(true);
            agent.speed = 0f;
            Debug.Log("Enemigo atacando");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); // Resetea el ataque con un intervalo

        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
        agent.speed = carSpeed;
    }

   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
