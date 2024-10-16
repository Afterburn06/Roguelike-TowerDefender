using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject uI;

    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;

    public Button upgradeButton;

    public Node target;
    public Turret turret;

    int cost;

    public void SetTarget(Node _target)
    {
        target = _target;
        turret = target.turret.GetComponent<Turret>();

        GetUpgradeCost();

        ShowUI();
    }

    public void ShowUI()
    {
        PopulateUI(target.turret.GetComponent<Turret>());
        uI.SetActive(true);
    }

    public void HideUI()
    {
        uI.SetActive(false);
    }

    public void PopulateUI(Turret t)
    {
        if (t.level == 5)
        {
            upgradeButton.interactable = false;
            upgradeText.text = "MAX Level";
        }
        else
        {
            upgradeButton.interactable = true;
            upgradeText.text = t.level.ToString() + "->" + (t.level + 1).ToString();
        }

        upgradeCost.text = "Upgrade: $" + cost;
    }

    public void Upgrade()
    {
        if (MoneyManager.currentMoney >= cost)
        {
            GetUpgradeCost();
            MoneyManager.currentMoney -= cost;
            turret.level++;
            PopulateUI(turret);
        }
    }

    public void GetUpgradeCost()
    {
        switch (turret.level)
        {
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
