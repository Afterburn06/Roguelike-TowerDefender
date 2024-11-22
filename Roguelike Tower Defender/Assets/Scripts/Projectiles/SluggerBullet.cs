using UnityEngine;

public class SluggerBullet : BasicBullet
{

    protected override void Update()
    {
        // Remove base functionality
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float distanceToTurret = Vector3.Distance(transform.position, turretTransform.position);

        if (distanceToTurret > turret.attackRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.transform != null)
            {
                target = other.transform;
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
