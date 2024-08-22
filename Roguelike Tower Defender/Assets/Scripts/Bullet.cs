using UnityEngine;

public class Bullet : Projectile
{
    public float speed = 70f;

    protected override void Update()
    {
        base.Update();

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Damage(target);

        Destroy(gameObject);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }
}
