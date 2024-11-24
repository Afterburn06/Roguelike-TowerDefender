using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [Header("Movespeed")]
    public float speed;

    [Header("Transforms")]
    protected private Transform target;
    protected private Transform turretTransform;

    protected private Turret turret;

    protected virtual void Update()
    {
        // If there is no target
        if (target == null)
        {
            // Destroy this object
            Destroy(gameObject);
            return;
        }

        // If the bullet has a target
        if (target != null)
        {
            // Get the direction to the target
            Vector3 dir = target.position - transform.position;
            // Get the distance that the bullet will travel this frame
            float distanceThisFrame = speed * Time.deltaTime;

            // If the distance to the enemy is less than the distance that will be travelled this frame
            if (dir.magnitude <= distanceThisFrame)
            {
                // Hit the target
                HitTarget();
                return;
            }

            // Move the bullet
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            // Rotate the bullet
            transform.LookAt(target);
        }
    }

    protected virtual void HitTarget()
    {
        // Damage the target
        Damage(target);
        // Destroy this bullet
        Destroy(gameObject);
    }

    protected virtual void Damage(Transform enemy)
    {
        // Get the Enemy script of the damaged object
        Enemy e = enemy.GetComponent<Enemy>();

        // If it is found
        if (e != null)
        {
            // Damage the enemy
            e.TakeDamage(turret.damage);
        }
    }

    public void Seek(Transform _target)
    {
        // Set the target variable in this script to the one passed in when the method was called
        target = _target;
    }

    public void GetReference(Turret _turret, Transform _turretTransform)
    {
        // Set the BasicBullet variables equal to the ones passed in
        turret = _turret;
        turretTransform = _turretTransform;
    }
}
