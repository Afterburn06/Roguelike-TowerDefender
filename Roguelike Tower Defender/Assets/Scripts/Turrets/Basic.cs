using UnityEngine;

public class Basic : Turret
{
    public float shotsPerSecond;
    private float shotCountdown = 0f;

    public GameObject bulletPrefab;

    protected override void Update()
    {
        base.Update();

        if (target != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

            if (shotCountdown <= 0f && distanceToEnemy <= attackRange)
            {
                Shoot();
                shotCountdown = 1f / shotsPerSecond;
            }
        }

        shotCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        TestBullet bullet = bulletGO.GetComponent<TestBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
