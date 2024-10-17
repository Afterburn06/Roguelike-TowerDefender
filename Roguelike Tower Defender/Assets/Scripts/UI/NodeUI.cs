using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [Header("UI Object")]
    public GameObject uI;

    [Header("Text Elements")]
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;

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
            // Set the upgrade text
            upgradeText.text = "MAX Level";
        }
        else
        {
            // Enable the upgrade button
            upgradeButton.interactable = true;
            // Set the upgrade text
            upgradeText.text = t.level.ToString() + "->" + (t.level + 1).ToString();
        }

        // Set the cost text to the cost variable
        upgradeCost.text = "Upgrade: $" + cost;
    }

    // Upgrade Button
    public void Upgrade()
    {
        // If the player has enough money
        if (MoneyManager.currentMoney >= cost)
        {
            // Get the upgrade cost
            GetUpgradeCost();
            // Take away money equal to the turret's cost
            MoneyManager.currentMoney -= cost;
            // Level up the turret
            turret.level++;
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
