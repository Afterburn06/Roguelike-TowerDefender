using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    
    private Transform endPoint;

    void Start()
    {
        // Get and store the transform of the end of the path
        endPoint = GameObject.FindGameObjectWithTag("End").transform;

        // Get and store the NavMeshAgent of this enemy
        agent = GetComponent<NavMeshAgent>();
        // Set the enemy's destination to the end of the path
        agent.SetDestination(endPoint.position);
    }

    void Update()
    {
        // If the enemy reaches the end of the path
        if(agent.transform.position.z == endPoint.position.z)
        {
            // Reduce the player's health
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        // Reduce the count of the amount of enemies alive
        EnemySpawner.enemiesAlive--;
        // Reduce the player's health by the amount left on this enemy
        PlayerStats.playerHealth -= this.GetComponent<Enemy>().currentHealth;
        // Destroy this enemy
        Destroy(gameObject);  
    }
}
