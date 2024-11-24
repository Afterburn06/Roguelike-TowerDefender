using UnityEngine;

public class Spitter : Turret
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
        tier = PlayerStats.spitterTier;
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
            // Upgrade the turret based on the level it's at currently
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
        // Get the upgrade text based on the turret's level
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

    public override void GetTierUpgradeDetails(InventoryTurretButton button)
    {
        // Get the tier upgrade text and cost based on the turret's level
        if (tier == 1)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +1";
            button.display.materialOneText.text = "5";
            button.display.materialTwoText.text = "1";
        }
        else if (tier == 2)
        {
            button.display.tierUpgradeDetailsText.text = "Range +2";
            button.display.materialOneText.text = "10";
            button.display.materialTwoText.text = "2";
        }
        else if (tier == 3)
        {
            button.display.tierUpgradeDetailsText.text = "Attack Speed +0.75";
            button.display.materialOneText.text = "20";
            button.display.materialTwoText.text = "4";
        }
        else if (tier == 4)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +3";
            button.display.materialOneText.text = "40";
            button.display.materialTwoText.text = "8";
        }
        else
        {
            button.display.tierUpgradeDetailsText.text = "MAX TIER UPGRADE REACHED";
            button.display.materialOneText.text = "";
            button.display.materialTwoText.text = "";
        }
    }

    public override void GetTierBonuses()
    {
        // Give the turret bonuses based on it's tier
        if (tier == 2)
        {
            damage++;
        }
        else if (tier == 3)
        {
            damage++;
            attackRange += 2;
        }
        else if (tier == 4)
        {
            damage++;
            attackRange += 2;
            shotsPerSecond += 0.75f;
        }
        else if (tier == 5)
        {
            attackRange += 2;
            shotsPerSecond += 0.75f;
            damage += 4;
        }
    }
}
