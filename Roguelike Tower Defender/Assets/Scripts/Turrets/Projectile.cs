using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected private Transform target;

    public int damage;

    protected virtual void Update()
    {
        // If there is no target
        if (target == null)
        {
            // Destroy this object
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void Damage(Transform enemy)
    {
        // Get the Enemy script of the damaged object
        Enemy e = enemy.GetComponent<Enemy>();

        // If it is found
        if (e != null)
        {
            // Damage the enemy
            e.TakeDamage(damage);
        }
    }
}
