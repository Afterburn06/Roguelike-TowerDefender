using UnityEngine;

public class Basic : Turret
{
    [Header("Firerate")]
    public float shotsPerSecond;

    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Start()
    {
        base.Start();
    }

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
        BasicBullet bullet = bulletGO.GetComponent<BasicBullet>();

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
                damage += 2;
                break;
            case 2:
                detectHidden = true;
                shotsPerSecond += 0.25f;
                break;
            case 3:
                damage += 3;
                attackRange += 1;
                break;
            case 4:
                damage += 3;
                shotsPerSecond += 0.5f; 
                break;
        }

        base.UpgradeTurret();
    }

    public override void GetUpgradeText(NodeUI uI)
    {
        switch (level)
        {
            case 1:
                uI.damageText.text = "Damage: " + damage + "→ " + "4";
                uI.rangeText.text = "Range: 2";
                uI.attackSpeedText.text = "Attack Speed: 0.75";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "";
                break;
            case 2:
                uI.damageText.text = "Damage: 4";
                uI.rangeText.text = "Range: 2";
                uI.attackSpeedText.text = "Attack Speed: 0.75 → 1";
                uI.hiddenDetectionText.text = "Hidden Detection: No → Yes";
                uI.otherText.text = "";
                break;
            case 3:
                uI.damageText.text = "Damage: " + damage + "→ " + "7";
                uI.rangeText.text = "Range: " + attackRange + "→ 3";
                uI.attackSpeedText.text = "Attack Speed: 1";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
            case 4:
                uI.damageText.text = "Damage: " + damage + "→ " + "10";
                uI.rangeText.text = "Range: 3";
                uI.attackSpeedText.text = "Attack Speed: 1 → 1.5";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
        }
    }
}
