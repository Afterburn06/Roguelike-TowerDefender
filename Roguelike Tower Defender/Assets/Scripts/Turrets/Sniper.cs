using UnityEngine;

public class Sniper : Turret
{
    [Header("Firerate")]
    public float shotsPerSecond;

    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Start()
    {
        base.Start();

        // Get the turret's tier
        tier = PlayerStats.sniperTier;
        // Get the bonuses from that tier
        GetTierBonuses();
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
        SniperBullet bullet = bulletGO.GetComponent<SniperBullet>();

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
            // Upgrade the turret based on the level it's at currently
            case 1:
                attackRange += 1;
                damage += 2;
                break;
            case 2:
                detectHidden = true;
                damage += 3;
                break;
            case 3:
                damage += 5;
                attackRange += 2;
                shotsPerSecond += 0.15f;
                break;
            case 4:
                damage += 8;
                attackRange += 2;
                break;
        }

        base.UpgradeTurret();
    }

    public override void GetUpgradeText(NodeUI uI)
    {
        // Get the upgrade text based on the turret's level
        switch (level)
        {
            case 1:
                uI.damageText.text = "Damage: " + damage + "→ " + "7";
                uI.rangeText.text = "Range: " + attackRange + "→ 6";
                uI.attackSpeedText.text = "Attack Speed: 0.2";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "";
                break;
            case 2:
                uI.damageText.text = "Damage: " + damage + "→ " + "10";
                uI.rangeText.text = "Range: 6";
                uI.attackSpeedText.text = "Attack Speed: 0.2";
                uI.hiddenDetectionText.text = "Hidden Detection: No → Yes";
                uI.otherText.text = "";
                break;
            case 3:
                uI.damageText.text = "Damage: " + damage + "→ " + "15";
                uI.rangeText.text = "Range: " + attackRange + "→ 8";
                uI.attackSpeedText.text = "Attack Speed: 0.2 → 0.35";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
            case 4:
                uI.damageText.text = "Damage: " + damage + "→ " + "23";
                uI.rangeText.text = "Range: " + attackRange + "→ 10";
                uI.attackSpeedText.text = "Attack Speed: 0.35";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
        }
    }

    public override void GetTierUpgradeDetails(InventoryTurretButton button)
    {
        // Get the tier upgrade text and cost based on the turret's level
        if (tier == 1)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +3";
            button.display.materialOneText.text = "5";
            button.display.materialTwoText.text = "1";
        }
        else if (tier == 2)
        {
            button.display.tierUpgradeDetailsText.text = "Range +5";
            button.display.materialOneText.text = "10";
            button.display.materialTwoText.text = "2";
        }
        else if (tier == 3)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +5";
            button.display.materialOneText.text = "20";
            button.display.materialTwoText.text = "4";
        }
        else if (tier == 4)
        {
            button.display.tierUpgradeDetailsText.text = "Range +10";
            button.display.materialOneText.text = "40";
            button.display.materialTwoText.text = "8";
        }
        else
        {
            button.display.tierUpgradeDetailsText.text = "";
            button.display.materialOneText.text = "";
            button.display.materialTwoText.text = "";
        }
    }

    public override void GetTierBonuses()
    {
        // Give the turret bonuses based on it's tier
        if (tier == 2)
        {
            damage += 3;
        }
        else if (tier == 3)
        {
            damage += 3;
            attackRange += 5;
        }
        else if (tier == 4)
        {
            attackRange += 5;
            damage += 8;
        }
        else if (tier == 5)
        {
            damage += 8;
            attackRange += 15;
        }
    }
}
