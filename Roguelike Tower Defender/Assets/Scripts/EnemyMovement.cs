using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    
    private Transform endPoint;

    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(endPoint.position);
    }

    void Update()
    {
        if(agent.transform.position.z == endPoint.position.z)
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        EnemySpawner.enemiesAlive--;
        Destroy(gameObject);  
    }
}
