using UnityEngine;

public class SluggerBullet : BasicBullet
{
    protected override void Update()
    {
        // Remove base functionality

        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Get the distance to the turret the bullet was fired from
        float distanceToTurret = Vector3.Distance(transform.position, turretTransform.position);

        // If this distance is greater than the turret's attack range
        if (distanceToTurret > turret.attackRange)
        {
            // Destroy this bullet
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the bullet hits an enemy
        if (other.gameObject.tag == "Enemy")
        {
            // If the other object has a transform
            if (other.transform != null)
            {
                // Set the target to the transform
                target = other.transform;
                // Hit the target
                HitTarget();
            }
        }
    }

    protected override void HitTarget()
    {
        // Damage the target
        Damage(target);
        // Destroy this bullet
        Destroy(gameObject);
    }
}
