using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public float startHealth;
    private float currentHealth;

    //[HideInInspector]
    public float currentSpeed;

    public int worth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        currentHealth = startHealth;
        currentSpeed = agent.speed;
    }

    void Update()
    {
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
