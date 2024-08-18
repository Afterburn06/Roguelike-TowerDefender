using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Stats")]
    public float startHealth;
    public float currentHealth;
    [HideInInspector]
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
        if (currentHealth <= 0f || GameManager.gameOver)
        {
            Die();
        }
    }

    void Die()
    {
        EnemySpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
