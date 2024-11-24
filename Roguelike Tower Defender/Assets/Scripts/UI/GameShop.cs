using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameShop : MonoBehaviour
{
    BuildManager buildManager;

    [Header("Buttons")]
    public Button turretOneButton;
    public Button turretTwoButton;
    public Button turretThreeButton;
    public Button turretFourButton;
    public Button turretFiveButton;

    [Header("Turrets")]
    public Turret turretOne;
    public Turret turretTwo;
    public Turret turretThree;
    public Turret turretFour;
    public Turret turretFive;

    [Header("Text Elements")]
    public TextMeshProUGUI buttonOneNameText;
    public TextMeshProUGUI buttonTwoNameText;
    public TextMeshProUGUI buttonThreeNameText;
    public TextMeshProUGUI buttonFourNameText;
    public TextMeshProUGUI buttonFiveNameText;
    public TextMeshProUGUI buttonOneCostText;
    public TextMeshProUGUI buttonTwoCostText;
    public TextMeshProUGUI buttonThreeCostText;
    public TextMeshProUGUI buttonFourCostText;
    public TextMeshProUGUI buttonFiveCostText;

    void Start()
    {
        // Set the buildManager variable to the current BuildManager in the scene
        buildManager = BuildManager.instance;
        
        IntialiseShop(); 
    }

    public void IntialiseShop()
    {
        // If there is a turret assigned to this button
        if (Inventory.turretOne != null)
        {
            // Set the text of the button to the name of the assigned turret
            buttonOneNameText.text = Inventory.turretOne.name;
            // Get the Turret script of the turret assigned to this button, store in in a variable
            turretOne = Inventory.turretOne.GetComponent<Turret>();

            buttonOneCostText.text = "$" + turretOne.baseCost;
        }

        // This and the rest of the function follow the same pattern as the last one, just for different buttons
        if (Inventory.turretTwo != null)
        {
            buttonTwoNameText.text = Inventory.turretTwo.name;
            turretTwo = Inventory.turretTwo.GetComponent<Turret>();

            buttonTwoCostText.text = "$" + turretTwo.baseCost;
        }

        if (Inventory.turretThree != null)
        {
            buttonThreeNameText.text = Inventory.turretThree.name;
            turretThree = Inventory.turretThree.GetComponent<Turret>();

            buttonThreeCostText.text = "$" + turretThree.baseCost;
        }

        if (Inventory.turretFour != null)
        {
            buttonFourNameText.text = Inventory.turretFour.name;
            turretFour = Inventory.turretFour.GetComponent<Turret>();

            buttonFourCostText.text = "$" + turretFour.baseCost;
        }

        if (Inventory.turretFive != null)
        {
            buttonFiveNameText.text = Inventory.turretFive.name;
            turretFive = Inventory.turretFive.GetComponent<Turret>();

            buttonFiveCostText.text = "$" + turretFive.baseCost;
        }
    }

    // First Turret Button
    public void ButtonOne()
    {
        // Select the Turret assigned to this button
        buildManager.SelectTurretToBuild(turretOne);
    }

    // Second Turret Button
    public void ButtonTwo()
    {
        // This and the other buttons follow the same pattern as ButtonOne
        buildManager.SelectTurretToBuild(turretTwo);
    }

    // Third Turret Button
    public void ButtonThree()
    {
        buildManager.SelectTurretToBuild(turretThree);
    }

    // Fourth Turret Button
    public void ButtonFour()
    {
        buildManager.SelectTurretToBuild(turretFour);
    }

    // Fifth Turret Button
    public void ButtonFive()
    {
        buildManager.SelectTurretToBuild(turretFive);
    }
}
