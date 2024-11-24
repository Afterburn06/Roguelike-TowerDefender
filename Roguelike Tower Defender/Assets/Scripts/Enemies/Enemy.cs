using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float startHealth;
    public int value;
    public bool hidden;
    
    [HideInInspector]
    public float currentSpeed;
    [HideInInspector]
    public float currentHealth;

    private NavMeshAgent agent;

    public virtual void Start()
    {
        // Get the NavMeshAgent of this enemy
        agent = GetComponent<NavMeshAgent>();

        // Set the enemy's health to it's starting health
        currentHealth = startHealth;
        // Set the enemy's speed to that in the NavMeshAgent
        currentSpeed = agent.speed;
    }

    protected virtual void Update()
    {
        // If the enemy has no health or the game is over
        if (currentHealth <= 0f || GameManager.gameOver)
        {
            Die();
        }

        if (GameManager.gamePaused)
        {
            Animator anim = this.GetComponent<Animator>();
            anim.enabled = false;
        }
        else
        {
            Animator anim = this.GetComponent<Animator>();
            anim.enabled = true;
        }
    }

    public void TakeDamage(float amount)
    {
        // Reduce the current health by the amount passed in
        currentHealth -= amount;
    }

    protected virtual void Die()
    {
        // Give the player money
        MoneyManager.currentMoney += value;
        // Reduce the count of the amount of enemies alive
        EnemySpawner.enemiesAlive--;
        // Destroy this enemy
        Destroy(gameObject);
    }
}
