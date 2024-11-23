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

        if (turret.name == "Slugger Turret" && !PlayerStats.sluggerUnlocked)
        {
            myText.text = "Locked";
            this.GetComponent<Button>().interactable = false;
        }

        if (turret.name == "Spitter Turret" && !PlayerStats.spitterUnlocked)
        {
            myText.text = "Locked";
            this.GetComponent<Button>().interactable = false;
        }

        if (turret.name == "Farm" && !PlayerStats.farmUnlocked)
        {
            myText.text = "Locked";
            this.GetComponent<Button>().interactable = false;
        }
    }

    // When the button is clicked
    public void OnClick()
    {
        // Set the display UI element's unit to be the turret assigned to this button
        display.currentUnit = turret;

        // Make the display UI values the turret assigned to this button's values
        display.displayImage.sprite = turretScript.turretSprite;

        Color newColor = display.displayImage.color;
        newColor.a = 1;
        display.displayImage.color = newColor;

        display.nameText.text = turret.name;
        display.tierText.text = "Tier: " + turretScript.tier;
        display.tierUpgradeText.text = "Tier " + turretScript.tier + " → " + (turretScript.tier + 1);

        // Get tier upgrade details such as stat increases and cost of the upgrade
        turretScript.GetTierUpgradeDetails(this);
    }
}
