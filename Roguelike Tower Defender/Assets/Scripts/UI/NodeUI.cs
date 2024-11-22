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

    private int cost;

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
        PopulateUI(target.turret.GetComponent<Turret>());
        // Enable the Node UI
        uI.SetActive(true);
    }

    public void HideUI()
    {
        // Disable the Node UI
        uI.SetActive(false);
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

        levelText.text = "Level " + t.level;

        if (t.GetComponent<Basic>() != null)
        {
            turretImage.sprite = basicImage;
        }
        else if (t.GetComponent<Sniper>() != null)
        {
            turretImage.sprite = sniperImage;
        }
        else if (t.GetComponent<Slugger>() != null)
        {
            turretImage.sprite = sluggerImage;
        }
        else if (t.GetComponent<Spitter>() != null)
        {
            turretImage.sprite = spitterImage;
        }
        else if (t.GetComponent<Farm>() != null)
        {
            turretImage.sprite = farmImage;
        }

        t.GetUpgradeText(this);

        // Set the cost text to the cost variable
        upgradeCost.text = "Upgrade: $" + cost;
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
        }
    }

    public void GetUpgradeCost()
    {
        // Depending on the turret's level
        switch (turret.level)
        {
            // Get the upgrade cost, set the cost variable to that amount
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
}
