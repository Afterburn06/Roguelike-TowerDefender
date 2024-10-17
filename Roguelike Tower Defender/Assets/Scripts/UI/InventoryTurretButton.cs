using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTurretButton : MonoBehaviour
{
    [Header("Assigned Turret")]
    public GameObject turret;

    [Header("UI Elements")]
    public Image image;
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
        }
        else
        {
            // Make the text blank
            myText.text = "";
        }
    }

    // When the button is clicked
    public void OnClick()
    {
        // Set the display UI element's unit to be the turret assigned to this button
        display.currentUnit = turret;
        // Make the display UI's text the turret assigned to this button's name
        display.statText.text = turret.name;
    }
}
