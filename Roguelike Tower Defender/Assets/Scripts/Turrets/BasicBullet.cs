using UnityEngine;

public class BasicBullet : Projectile
{
    [Header("Movespeed")]
    public float speed;

    protected override void Update()
    {
        // Use the base projectile functionality
        base.Update();

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

    void HitTarget()
    {
        // Damage the target
        Damage(target);
        // Destroy this bullet
        Destroy(gameObject);
    }

    public void Seek(Transform _target)
    {
        // Set the target variable in this script to the one passed in when the method was called
        target = _target;
    }
}
