using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected private Transform target;

    public int damage;

    protected virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
