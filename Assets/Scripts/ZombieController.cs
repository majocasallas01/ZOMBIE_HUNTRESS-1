using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    public GameObject jugador;
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth

    // Añadido: referencia al componente Animator
    public Animator animator;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Obtener la referencia al Animator en el mismo GameObject
        enemyHealth = GetComponent<EnemyHealth>(); // Obtener la referencia al script EnemyHealth en el mismo GameObject
        // myNavMeshAgent.enabled = true; // No es necesario habilitar ya que se activa por defecto
    }

    void FixedUpdate()
    {
        if (myNavMeshAgent.enabled)
        {
            myNavMeshAgent.SetDestination(jugador.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myNavMeshAgent.enabled = false; // Deshabilitar NavMeshAgent cuando colisiona con el jugador

            // Añadido: activar la animación de ataque
            animator.SetBool("Attack", true);
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            // Reducir la vida del zombie utilizando el script EnemyHealth
            enemyHealth.TakeDamage(1);
        }
    }
}
