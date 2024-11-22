using UnityEngine;

public class Spitter : Turret
{
    [Header("Firerate")]
    public float shotsPerSecond;

    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Update()
    {
        // Use the base Turret functionality
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
        // Instantiate a new bullet, store it in a variable
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Get the bullet script
        SpitterBullet bullet = bulletGO.GetComponent<SpitterBullet>();

        // If there is a script
        if (bullet != null)
        {
            bullet.GetReference(this.GetComponent<Turret>(), this.transform);
            // Make the bullet seek the target enemy
            bullet.Seek(target);
        }
    }

    public override void UpgradeTurret()
    {
        switch (level)
        {
            case 1:
                damage++;
                break;
            case 2:
                shotsPerSecond += 0.5f;
                attackRange++;
                break;
            case 3:
                detectHidden = true;
                damage++;
                break;
            case 4:
                damage += 2;
                attackRange += 2;
                shotsPerSecond += 1.5f;
                break;
        }

        base.UpgradeTurret();
    }

    public override void GetUpgradeText(NodeUI uI)
    {
        switch (level)
        {
            case 1:
                uI.damageText.text = "Damage: " + damage + "→ " + "2";
                uI.rangeText.text = "Range: 3";
                uI.attackSpeedText.text = "Attack Speed: 3";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "";
                break;
            case 2:
                uI.damageText.text = "Damage: 2";
                uI.rangeText.text = "Range: 3 → 4";
                uI.attackSpeedText.text = "Attack Speed: 3 → 3.5";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "";
                break;
            case 3:
                uI.damageText.text = "Damage: " + damage + "→ " + "3";
                uI.rangeText.text = "Range: 4";
                uI.attackSpeedText.text = "Attack Speed: 1";
                uI.hiddenDetectionText.text = "Hidden Detection: No → Yes";
                uI.otherText.text = "";
                break;
            case 4:
                uI.damageText.text = "Damage: " + damage + "→ " + "5";
                uI.rangeText.text = "Range: 4 → 6";
                uI.attackSpeedText.text = "Attack Speed: 3.5 → 5";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
        }
    }
}
