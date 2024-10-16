using UnityEngine;

public class Turret : MonoBehaviour
{
    protected private Transform target;
    private Enemy targetEnemy;
    private string enemyTag = "Enemy";

    private bool lockedOn;

    [Header("Turret Parts")]
    public Transform partToRotate;
    public Transform firePoint;

    [Header("Stats")]
    private float lockRange;
    public float attackRange;
    public float turnSpeed;
    public int level;

    [Header("Purchase / Upgrade Costs")]
    public int baseCost;
    public int levelTwoCost;
    public int levelThreeCost;
    public int levelFourCost;
    public int levelFiveCost;

    [Header("Prefabs")]
    public GameObject levelOnePrefab;
    public GameObject levelTwoPrefab;
    public GameObject levelThreePrefab;
    public GameObject levelFourPrefab;
    public GameObject levelFivePrefab;

    [Header("Other")]
    public Vector3 positionOffset;

    void Start()
    {
        lockedOn = false;
        lockRange = attackRange + attackRange / 3;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            lockedOn = false;
            return;
        }

        LockOnTarget();
    }

    void UpdateTarget()
    {
        // If already targetting
        if (lockedOn)
        {
            // Exit loop
            return;
        }

        // Create an array, fill it with enemies in range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        // For each enemy
        foreach (GameObject enemy in enemies)
        {
            // Get the distance to it
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            // If it is the closest enemy
            if (distanceToEnemy < shortestDistance)
            {
                // Set the shortest distance to an enemy to the distance to this one, make this enemy the nearest enemy
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If an enemy has been found and it is withing lock on range
        if (nearestEnemy != null && shortestDistance <= lockRange)
        {
            // Get it's transform and Enemy script
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            
            lockedOn = true;
        }
        else
        {
            // There is no target
            target = null;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}
