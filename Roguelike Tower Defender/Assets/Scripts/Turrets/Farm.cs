using UnityEngine;

public class Farm : Turret
{
    private EnemySpawner enemySpawner;

    private int lastWave;

    private int moneyProduced;

    [Header("Money Produced")]
    public int levelOneMoneyProduced;
    public int levelTwoMoneyProduced;
    public int levelThreeMoneyProduced;
    public int levelFourMoneyProduced;
    public int levelFiveMoneyProduced;

    protected override void Start()
    {
        // Remove Turret script Start() functionality

        // New functionality
        enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();

        // Reset last wave counter
        lastWave = 1;

        // Get the turret's tier
        tier = PlayerStats.farmTier;
        // Get the bonuses from that tier
        GetTierBonuses();
    }

    protected override void Update()
    {
        // Remove Turret script Update() functionality

        // New functionality
        switch (level)
        {
            // Get the amount of money produced based on the turret's level
            case 1:
                moneyProduced = levelOneMoneyProduced;
                break;
            case 2:
                moneyProduced = levelTwoMoneyProduced;
                break;
            case 3:
                moneyProduced = levelThreeMoneyProduced;
                break;
            case 4:
                moneyProduced = levelFourMoneyProduced;
                break;
            case 5:
                moneyProduced = levelFiveMoneyProduced;
                break;
        }

        // If the last wave number is less than the current wave
        if (lastWave < enemySpawner.waveCount)
        {
            // Add money
            MoneyManager.currentMoney += moneyProduced;
            // Change the last wave counter
            lastWave = enemySpawner.waveCount;
        }
    }

    public override void GetUpgradeText(NodeUI uI)
    {
        switch (level)
        {
            // Get the upgrade text based on the turret's level
            case 1:
                uI.damageText.text = "Production: $100 → $200";
                uI.rangeText.text = "";
                uI.attackSpeedText.text = "";
                uI.hiddenDetectionText.text = "";
                uI.otherText.text = "";
                break;
            case 2:
                uI.damageText.text = "Production: $200 → $350";
                uI.rangeText.text = "";
                uI.attackSpeedText.text = "";
                uI.hiddenDetectionText.text = "";
                uI.otherText.text = "";
                break;
            case 3:
                uI.damageText.text = "Production: $350 → $500";
                uI.rangeText.text = "";
                uI.attackSpeedText.text = "";
                uI.hiddenDetectionText.text = "";
                uI.otherText.text = "";
                break;
            case 4:
                uI.damageText.text = "Production: $500 → $700";
                uI.rangeText.text = "";
                uI.attackSpeedText.text = "";
                uI.hiddenDetectionText.text = "";
                uI.otherText.text = "";
                break;
        }
    }

    public override void GetTierUpgradeDetails(InventoryTurretButton button)
    {
        // Get the tier upgrade text and cost based on the turret's level
        if (tier == 1)
        {
            button.display.tierUpgradeDetailsText.text = "Production +$25";
            button.display.materialOneText.text = "5";
            button.display.materialTwoText.text = "0";
        }
        else if (tier == 2)
        {
            button.display.tierUpgradeDetailsText.text = "Production +$25";
            button.display.materialOneText.text = "10";
            button.display.materialTwoText.text = "0";
        }
        else if (tier == 3)
        {
            button.display.tierUpgradeDetailsText.text = "Production +$50";
            button.display.materialOneText.text = "15";
            button.display.materialTwoText.text = "1";
        }
        else if (tier == 4)
        {
            button.display.tierUpgradeDetailsText.text = "Production +$100";
            button.display.materialOneText.text = "20";
            button.display.materialTwoText.text = "2";
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
            moneyProduced += 25;
        }
        else if (tier == 3)
        {
            moneyProduced += 50;
        }
        else if (tier == 4)
        {
            moneyProduced += 100;
        }
        else if (tier == 5)
        {
            moneyProduced += 200;
        }
    }

    protected override void OnDrawGizmosSelected()
    {
        // Remove Turret script OnDrawGizmosSelected() functionality
    }
}
