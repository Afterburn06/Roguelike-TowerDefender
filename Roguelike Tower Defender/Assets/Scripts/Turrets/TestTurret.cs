using UnityEngine;

public class TestTurret : Turret
{
    public float shotsPerSecond = 1f;
    private float shotCountdown = 0f;
    
    public GameObject bulletPrefab;

    protected override void Update()
    {
        base.Update();

        if (shotCountdown <= 0f && target != null)
        {
            Shoot();
            shotCountdown = 1f / shotsPerSecond;
        }

        shotCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
