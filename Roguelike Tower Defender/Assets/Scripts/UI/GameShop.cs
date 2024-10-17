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

    void Start()
    {
        // Set the buildManager variable to the current BuildManager in the scene
        buildManager = BuildManager.instance;
        
        IntialiseShop(); 
    }

    public void IntialiseShop()
    {
        // Get the text elements of the turret buttons, store them as local variables
        TextMeshProUGUI buttonOneText = turretOneButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonTwoText = turretTwoButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonThreeText = turretThreeButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonFourText = turretFourButton.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonFiveText = turretFiveButton.GetComponentInChildren<TextMeshProUGUI>();

        // If there is a turret assigned to this button
        if (Inventory.turretOne != null)
        {
            // Set the text of the button to the name of the assigned turret
            buttonOneText.text = Inventory.turretOne.name;
            // Get the Turret script of the turret assigned to this button, store in in a variable
            turretOne = Inventory.turretOne.GetComponent<Turret>();
        }

        // This and the rest of the function follow the same pattern as the last one, just for different buttons
        if (Inventory.turretTwo != null)
        {
            buttonTwoText.text = Inventory.turretTwo.name;
            turretTwo = Inventory.turretTwo.GetComponent<Turret>();
        }

        if (Inventory.turretThree != null)
        {
            buttonThreeText.text = Inventory.turretThree.name;
            turretThree = Inventory.turretThree.GetComponent<Turret>();
        }

        if (Inventory.turretFour != null)
        {
            buttonFourText.text = Inventory.turretFour.name;
            turretFour = Inventory.turretFour.GetComponent<Turret>();
        }

        if (Inventory.turretFive != null)
        {
            buttonFiveText.text = Inventory.turretFive.name;
            turretFive = Inventory.turretFive.GetComponent<Turret>();
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
