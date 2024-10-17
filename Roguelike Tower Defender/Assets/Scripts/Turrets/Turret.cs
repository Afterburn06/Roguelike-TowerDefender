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

    [Header("Prefabs")]
    public GameObject levelOnePrefab;
    public GameObject levelTwoPrefab;
    public GameObject levelThreePrefab;
    public GameObject levelFourPrefab;
    public GameObject levelFivePrefab;

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

    [Header("Offset")]
    public Vector3 positionOffset;

    void Start()
    {
        // Reset the locked on variable
        lockedOn = false;
        // Set the lock on range to a quarter of the attack range plus that range
        lockRange = attackRange + attackRange / 4;

        // Start checking for targets every 0.5 seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected virtual void Update()
    {
        // If there is no target
        if (target == null)
        {
            // The turret is no longer locked on
            lockedOn = false;
            return;
        }

        // Lock onto a target
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
        
        // Reset the nearest enemy variable
        GameObject nearestEnemy = null;
        // Reset the shortest distance variable
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
            
            // The turret is locked on
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
        // Get the direction to the target
        Vector3 dir = target.position - transform.position;
        // Get the amount needed to rotate to the target
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Get a Vector3 variable of the rotation required, smoothed
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // Rotate the turret
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // When selected in the editor
    void OnDrawGizmosSelected()
    {
        // Draw the attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw the lock on range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}
