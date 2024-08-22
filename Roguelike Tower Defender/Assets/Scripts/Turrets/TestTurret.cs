using UnityEngine;

public class TestTurret : Turret
{
    public float shotsPerSecond = 1f;
    private float shotCountdown = 0f;
    
    public GameObject bulletPrefab;

    protected override void Update()
    {
        base.Update();

        if (target != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

            if (shotCountdown <= 0f && distanceToEnemy <= shootRange)
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
