using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HealingSystem : MonoBehaviour
{

    [Header("AI Conf")]
    [SerializeField] NavMeshAgent agent; // Ref al componente Agente, que permite que el objeto tenga IA
    [SerializeField] Transform target; // Ref al transform del objeto que la IA va a perseguir
    [SerializeField] LayerMask targetLayer; // Determina cual es la capa de deteccion del target
    [SerializeField] LayerMask groundLayer; // Determina cual es la capa de detección del suelo

    [Header("States & Detection")]
    [SerializeField] float sightRange;
    [SerializeField] bool targetInSightRange; // Bool que determina si el target está a distancia de detección

    [SerializeField] float heal;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
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
        if (targetInSightRange) ChaseTarget();
    }

    void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            healthSystem.health += heal;
            gameObject.SetActive(false);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
