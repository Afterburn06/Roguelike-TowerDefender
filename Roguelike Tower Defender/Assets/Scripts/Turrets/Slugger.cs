using UnityEngine;

public class Slugger : Turret
{
    [Header("Stats")]
    public float shotsPerSecond;
    public int numOfBullets;
    
    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Update()
    {
        base.Update();

        // If the turret has a target
        if (target != null)
        {
            // Get the distance to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

            // If the shot has reloaded and the enemy is in attack range
            if (shotCountdown <= 0f && distanceToEnemy <= attackRange)
            {
                // Shoot it
                Shoot();
                // Reset the shot countdown
                shotCountdown = 1f / shotsPerSecond;
            }
        }

        // Reduce the shot countdown by one per second
        shotCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        for (int i = 0; i < numOfBullets; i++)
        {
            float xRot = Random.Range(15.0f, -15.0f);
            float yRot = Random.Range(15.0f, -15.0f);

            Quaternion rotation = Quaternion.Euler(xRot, yRot, 0);

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            SluggerBullet bullet = bulletGO.GetComponent<SluggerBullet>();

            bulletGO.transform.Rotate(xRot, yRot, 0);

            if (bullet != null)
            {
                bullet.GetReference(this.GetComponent<Turret>(), this.transform);
            }
        }
    }
}
