using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameShop : MonoBehaviour
{
    BuildManager buildManager;

    [Header("Buttons")]
    public Button unitOneButton;
    public Button unitTwoButton;
    public Button unitThreeButton;
    public Button unitFourButton;
    public Button unitFiveButton;

    [Header("Turrets")]
    public Turret turretOne;
    public Turret turretTwo;
    public Turret turretThree;
    public Turret turretFour;
    public Turret turretFive;

    void Start()
    {
        IntialiseShop();
        buildManager = BuildManager.instance;
    }

    public void IntialiseShop()
    {
        TextMeshProUGUI buttonOneText = unitOneButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonTwoText = unitTwoButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonThreeText = unitThreeButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonFourText = unitFourButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonFiveText = unitFiveButton.GetComponentInChildren<TextMeshProUGUI>();

        if (Inventory.unitOne != null)
        {
            buttonOneText.text = Inventory.unitOne.name;
            turretOne = Inventory.unitOne.GetComponent<Turret>();
        }

        if (Inventory.unitTwo != null)
        {
            buttonTwoText.text = Inventory.unitTwo.name;
            turretTwo = Inventory.unitTwo.GetComponent<Turret>();
        }

        if (Inventory.unitThree != null)
        {
            buttonThreeText.text = Inventory.unitThree.name;
            turretThree = Inventory.unitThree.GetComponent<Turret>();
        }

        if (Inventory.unitFour != null)
        {
            buttonFourText.text = Inventory.unitFour.name;
            turretFour = Inventory.unitFour.GetComponent<Turret>();
        }

        if (Inventory.unitFive != null)
        {
            buttonFiveText.text = Inventory.unitFive.name;
            turretFive = Inventory.unitFive.GetComponent<Turret>();
        }
    }

    public void ButtonOne()
    {
        buildManager.SelectTurretToBuild(turretOne);
    }

    public void ButtonTwo()
    {
        buildManager.SelectTurretToBuild(turretTwo);
    }

    public void ButtonThree()
    {
        buildManager.SelectTurretToBuild(turretThree);
    }

    public void ButtonFour()
    {
        buildManager.SelectTurretToBuild(turretFour);
    }

    public void ButtonFive()
    {
        buildManager.SelectTurretToBuild(turretFive);
    }
}
