using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [Header("UI Object")]
    public GameObject uI;

    [Header("Text Elements")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI hiddenDetectionText;
    public TextMeshProUGUI otherText;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;

    [Header("Images")]
    public Image turretImage;
    public Sprite basicImage;
    public Sprite sniperImage;
    public Sprite sluggerImage;
    public Sprite spitterImage;
    public Sprite farmImage;

    [Header("Buttons")]
    public Button upgradeButton;
    public Button sellButton;

    [Header("Misc")]
    public Node target;
    public Turret turret;
    public GameObject rangeIndicator;

    private int cost;
    private int sellValue;

    void Update()
    {
        // If the game is paused
        if (GameManager.gamePaused)
        {
            // Hide UI
            HideUI();
        }
    }

    public void SetTarget(Node _target)
    {
        // Set the NodeUI target variable to the Node passed in when the method is called
        target = _target;
        // Get the turret from that node
        turret = target.turret.GetComponent<Turret>();

        // Call methods
        GetUpgradeCost();
        ShowUI();
    }

    public void ShowUI()
    {
        // Populate the UI with the selected turret's info
        PopulateUI(turret);
        // Enable the Node UI
        uI.SetActive(true);

        // Turn on the range indicator and set its position and size
        rangeIndicator.transform.position = new Vector3(target.turret.transform.position.x, 0, target.turret.transform.position.z);
        rangeIndicator.transform.localScale = new Vector3(turret.attackRange, 0.01f, turret.attackRange);
        rangeIndicator.SetActive(true);
    }

    public void HideUI()
    {
        // Disable the Node UI and range indicator
        uI.SetActive(false);
        rangeIndicator.SetActive(false);
    }

    public void PopulateUI(Turret t)
    {
        // If the selected turret is max level
        if (t.level == 5)
        {
            // Disable the upgrade button
            upgradeButton.interactable = false;
        }
        else
        {
            // Enable the upgrade button
            upgradeButton.interactable = true;
        }

        // Set the level text
        levelText.text = "Level " + t.level;

        // Set the turret image
        turretImage.sprite = t.turretSprite;

        // Get the upgrade text from the turret
        t.GetUpgradeText(this);

        // Set the cost text to the cost variable
        upgradeCost.text = "Upgrade: $" + cost;

        // Get the sell value of the turret
        GetSellValue();

        // Set the sell text
        sellAmount.text = "Sell: $" + sellValue;
    }

    // Upgrade Button
    public void Upgrade()
    {
        // If the player has enough money
        if (MoneyManager.currentMoney >= cost)
        {
            // Take away money equal to the turret's cost
            MoneyManager.currentMoney -= cost;
            // Level up the turret
            turret.UpgradeTurret();
            // Get the upgrade cost
            GetUpgradeCost();
            // Reload the UI with the new stats
            PopulateUI(turret);
            rangeIndicator.transform.localScale = new Vector3(turret.attackRange, 0.01f, turret.attackRange);
        }
    }

    public void GetUpgradeCost()
    {
        switch (turret.level)
        {
            // Get the upgrade cost based on the turret's level, set the cost variable to that amount
            case 1:
                cost = turret.levelTwoCost;
                break;
            case 2:
                cost = turret.levelThreeCost;
                break;
            case 3:
                cost = turret.levelFourCost;
                break;
            case 4:
                cost = turret.levelFiveCost;
                break;
        }
    }

    public void Sell()
    {
        // Give the player money
        MoneyManager.currentMoney += sellValue;
        // Take a turret away from the counter of turrets placed
        TurretManager.currentUnits--;

        // Destroy the turret
        Destroy(target.turret);
        // Hide the UI
        HideUI();
    }

    public void GetSellValue()
    {
        switch (turret.level)
        {
            // Get the sell cost based on the turret's level, set the sellValue variable to that amount
            case 1:
                sellValue = turret.baseCost / 2;
                break;
            case 2:
                sellValue = (turret.baseCost + turret.levelTwoCost) / 2;
                break;
            case 3:
                sellValue = (turret.baseCost + turret.levelTwoCost + turret.levelThreeCost) / 2;
                break;
            case 4:
                sellValue = (turret.baseCost + turret.levelTwoCost + turret.levelThreeCost + turret.levelFourCost) / 2;
                break;
            case 5:
                sellValue = (turret.baseCost + turret.levelTwoCost + turret.levelThreeCost + turret.levelFourCost + turret.levelFiveCost) / 2;
                break;
        }
    }
}
