using UnityEngine;

public class Slugger : Turret
{
    [Header("Stats")]
    public float shotsPerSecond;
    public int numOfBullets;
    
    [Header("Bullet")]
    public GameObject bulletPrefab;

    private float shotCountdown;

    protected override void Start()
    {
        base.Start();

        // Get the turret's tier
        tier = PlayerStats.sluggerTier;
        // Get the bonuses from that tier
        GetTierBonuses();
    }

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

    public override void UpgradeTurret()
    {
        switch (level)
        {
            // Upgrade the turret based on the level it's at currently
            case 1:
                damage++;
                numOfBullets++;
                break;
            case 2:
                damage++;
                shotsPerSecond += 0.15f;
                numOfBullets++;
                break;
            case 3:
                damage += 2;
                attackRange += 1;
                shotsPerSecond += 0.1f;
                break;
            case 4:
                damage += 2;
                shotsPerSecond += 0.5f;
                numOfBullets += 2;
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
                uI.rangeText.text = "Range: 1.5";
                uI.attackSpeedText.text = "Attack Speed: 0.25";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "Number of Bullets: 5 → 6";
                break;
            case 2:
                uI.damageText.text = "Damage: " + damage + "→ " + "3";
                uI.rangeText.text = "Range: 1.5";
                uI.attackSpeedText.text = "Attack Speed: 0.25 → 0.4";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "Number of Bullets: 6 → 7";
                break;
            case 3:
                uI.damageText.text = "Damage: " + damage + "→ " + "5";
                uI.rangeText.text = "Range: " + attackRange + "→ 2.5";
                uI.attackSpeedText.text = "Attack Speed: 0.4 → 0.5";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "Number of Bullets: 7";
                break;
            case 4:
                uI.damageText.text = "Damage: " + damage + "→ " + "7";
                uI.rangeText.text = "Range: 2.5";
                uI.attackSpeedText.text = "Attack Speed: 0.5 → 1";
                uI.hiddenDetectionText.text = "Hidden Detection: No";
                uI.otherText.text = "Number of Bullets: 7 → 9";
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
            button.display.tierUpgradeDetailsText.text = "Number of Bullets +1";
            button.display.materialOneText.text = "10";
            button.display.materialTwoText.text = "2";
        }
        else if (tier == 3)
        {
            button.display.tierUpgradeDetailsText.text = "Number of Bullets +2";
            button.display.materialOneText.text = "20";
            button.display.materialTwoText.text = "4";
        }
        else if (tier == 4)
        {
            button.display.tierUpgradeDetailsText.text = "Damage +2";
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
            numOfBullets++;
        }
        else if (tier == 4)
        {
            damage++;
            numOfBullets += 3;
        }
        else if (tier == 5)
        {
            numOfBullets += 3;
            damage += 3;
        }
    }
}
