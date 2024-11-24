﻿using UnityEngine;

public class Basic : Turret
{
    [Header("Firerate")]
    public float shotsPerSecond;

    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Start()
    {
        // Use base Turret functipo
        base.Start();

        // Get the turret's tier
        tier = PlayerStats.basicTier;
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
            // Upgrade the turret based on the level it's at currently
            case 1:
                damage++;
                break;
            case 2:
                detectHidden = true;
                shotsPerSecond += 0.25f;
                break;
            case 3:
                damage += 2;
                attackRange += 1;
                break;
            case 4:
                damage += 3;
                shotsPerSecond += 0.25f; 
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
                uI.damageText.text = "Damage: " + damage + "→ " + "3";
                uI.rangeText.text = "Range: 2";
                uI.attackSpeedText.text = "Attack Speed: 0.75";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "";
                break;
            case 2:
                uI.damageText.text = "Damage: 3";
                uI.rangeText.text = "Range: 2";
                uI.attackSpeedText.text = "Attack Speed: 0.75 → 1";
                uI.hiddenDetectionText.text = "Hidden Detection: No → Yes";
                uI.otherText.text = "";
                break;
            case 3:
                uI.damageText.text = "Damage: " + damage + "→ " + "5";
                uI.rangeText.text = "Range: " + attackRange + "→ 3";
                uI.attackSpeedText.text = "Attack Speed: 1";
                uI.hiddenDetectionText.text = "Hidden Detection: Yes";
                uI.otherText.text = "";
                break;
            case 4:
                uI.damageText.text = "Damage: " + damage + "→ " + "8";
                uI.rangeText.text = "Range: 3";
                uI.attackSpeedText.text = "Attack Speed: 1 → 1.25";
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
            button.display.tierUpgradeDetailsText.text = "Range +1";
            button.display.materialOneText.text = "10";
            button.display.materialTwoText.text = "2";
        }
        else if (tier == 3)
        {
            button.display.tierUpgradeDetailsText.text = "Attack Speed +0.25";
            button.display.materialOneText.text = "20";
            button.display.materialTwoText.text = "4";
        }
        else if (tier == 4)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +5";
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
            damage++;
        }
        else if (tier == 3)
        {
            damage++;
            attackRange++;
        }
        else if (tier == 4)
        {
            damage++;
            attackRange++;
            shotsPerSecond += 0.25f;
        }
        else if (tier == 5)
        {
            attackRange++;
            shotsPerSecond += 0.25f;
            damage += 6;
        }
    }
}
