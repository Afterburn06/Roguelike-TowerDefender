using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Sprite turretSprite;

    protected private Transform target;
    private Enemy targetEnemy;
    private string enemyTag = "Enemy";
    private string hiddenEnemyTag = "Hidden Enemy";

    private bool lockedOn;

    [Header("Turret Parts")]
    public Transform partToRotate;
    public Transform firePoint;
    public int allowedLayer;

    [Header("Prefabs")]
    public GameObject basePrefab;

    [Header("Stats")]
    public float attackRange;
    private float lockRange;
    public float turnSpeed;
    public int level;
    public int tier;
    public float damage;
    public bool detectHidden;

    [Header("Purchase / Upgrade Costs")]
    public int baseCost;
    public int levelTwoCost;
    public int levelThreeCost;
    public int levelFourCost;
    public int levelFiveCost;

    [Header("Offset")]
    public Vector3 positionOffset;

    protected virtual void Start()
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

    protected virtual void UpdateTarget()
    {
        // If already targetting
        if (lockedOn)
        {
            // Check if the target is still in range
            CheckInRange();
            return;
        }

        // Create an array, fill it with enemies in range
        GameObject[] enemies = null;
        
        if (!detectHidden)
        {
            enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        }
        else if (detectHidden)
        {
            GameObject[] hiddenEnemies = GameObject.FindGameObjectsWithTag(hiddenEnemyTag);
            GameObject[] seenEnemies = GameObject.FindGameObjectsWithTag(enemyTag);

            enemies = hiddenEnemies.Concat(seenEnemies).ToArray();
        }
        
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

        // If an enemy has been found and it is within lock on range
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

    protected virtual void LockOnTarget()
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

    protected virtual void CheckInRange()
    {
        // Get the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
        // If the target is not in attack range
        if (distanceToTarget > attackRange)
        {
            // The turret is no longer locked on
            lockedOn = false;
        }
    }

    public virtual void UpgradeTurret()
    {
        level++;
    }

    public virtual void GetUpgradeText(NodeUI uI)
    {

    }

    public virtual void GetTierUpgradeDetails(InventoryTurretButton button)
    {

    }

    // When selected in the editor
    protected virtual void OnDrawGizmosSelected()
    {
        // Draw the attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw the lock on range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}
