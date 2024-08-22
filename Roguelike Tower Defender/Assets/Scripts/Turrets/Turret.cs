using UnityEngine;

public class Turret : MonoBehaviour
{
    protected private Transform target;
    private Enemy targetEnemy;
    private string enemyTag = "Enemy";
    
    public Transform partToRotate;
    public Transform firePoint;

    private float lockRange;
    public float shootRange;
    public float turnSpeed;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        lockRange = shootRange + shootRange / 3;
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            return;
        }

        LockOnTarget();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= lockRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
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
        Gizmos.DrawWireSphere(transform.position, shootRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}
