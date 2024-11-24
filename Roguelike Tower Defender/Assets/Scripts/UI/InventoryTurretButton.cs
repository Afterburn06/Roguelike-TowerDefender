using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTurretButton : MonoBehaviour
{
    [Header("Assigned Turret")]
    public GameObject turret;
    public Turret turretScript;

    [Header("UI Elements")]
    public Display display;
    public TextMeshProUGUI myText;
    public Button upgradeButton;

    [Header("Equipped Turret Buttons")]
    public EquippedTurretButton buttonOne;
    public EquippedTurretButton buttonTwo;
    public EquippedTurretButton buttonThree;
    public EquippedTurretButton buttonFour;
    public EquippedTurretButton buttonFive;

    void Start()
    {
        // If this button has a turret assigned
        if (turret != null)
        {
            // Set the text to display the turrets name
            myText.text = turret.name;
            turretScript = turret.GetComponent<Turret>();
        }
        else
        {
            // Make the text blank
            myText.text = "";
        }

        // If the turret is the slugger turret and it is not unlocked
        if (turret.name == "Slugger Turret" && !PlayerStats.sluggerUnlocked)
        {
            // Change text
            myText.text = "Locked";
            // Disable button
            this.GetComponent<Button>().interactable = false;
        }

        // If the turret is the spitter turret and it is not unlocked
        if (turret.name == "Spitter Turret" && !PlayerStats.spitterUnlocked)
        {
            // Change text
            myText.text = "Locked";
            // Disable button
            this.GetComponent<Button>().interactable = false;
        }

        // If the turret is the farm and it is not unlocked
        if (turret.name == "Farm" && !PlayerStats.farmUnlocked)
        {
            // Change text
            myText.text = "Locked";
            // Disable button
            this.GetComponent<Button>().interactable = false;
        }
    }

    // When the button is clicked
    public void OnClick()
    {
        // Set the last presed button to this button
        display.lastPressedButton = this;

        // Set the display UI element's unit to be the turret assigned to this button
        display.currentUnit = turret;

        // Make the display UI values the turret assigned to this button's values
        display.displayImage.sprite = turretScript.turretSprite;

        // Make the turret image opaque
        Color newColor = display.displayImage.color;
        newColor.a = 1;
        display.displayImage.color = newColor;

        // Change text elements
        display.nameText.text = turret.name;
        display.tierText.text = "Tier: " + turretScript.tier;
        display.tierUpgradeText.text = "Tier " + turretScript.tier + " → " + (turretScript.tier + 1);

        // Get tier upgrade details such as stat increases and cost of the upgrade
        turretScript.GetTierUpgradeDetails(this);

        // Get the material required from the string
        int materialOneRequired = Convert.ToInt32(display.materialOneText.text);
        int materialTwoRequired = Convert.ToInt32(display.materialTwoText.text);

        // If the player can't afford the upgrade
        if (materialOneRequired > PlayerStats.materialOneAmount || materialTwoRequired > PlayerStats.materialTwoAmount)
        {
            // Disable the button
            upgradeButton.interactable = false;
        }
        else
        {
            // Enable the button
            upgradeButton.interactable = true;
        }
    }
}
