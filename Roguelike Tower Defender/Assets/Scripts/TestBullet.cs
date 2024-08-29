using UnityEngine;

public class TestBullet : Projectile
{
    public float speed;

    protected override void Update()
    {
        base.Update();

        if (target != null)
        {
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
