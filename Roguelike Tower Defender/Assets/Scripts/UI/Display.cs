using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [Header("Equipped Turret Buttons")]
    public EquippedTurretButton buttonOne;
    public EquippedTurretButton buttonTwo;
    public EquippedTurretButton buttonThree;
    public EquippedTurretButton buttonFour;
    public EquippedTurretButton buttonFive;
    
    [Header("UI")]
    public Image displayImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI tierText;
    public TextMeshProUGUI tierUpgradeText;
    public TextMeshProUGUI tierUpgradeDetailsText;
    public TextMeshProUGUI materialOneText;
    public TextMeshProUGUI materialTwoText;
    public Image materialOneImage;
    public Image materialTwoImage;

    [HideInInspector]
    public GameObject currentUnit;
    private int turretNum;

    // Equip to Slot One Button
    public void SlotOne()
    {
        // Set Button One's turret to the one assigned to this button
        buttonOne.myTurret = currentUnit;

        GetTurretNum(buttonOne);
        PlayerStats.equippedTurretOne = turretNum;
        
        // Remove this turret from the 
        RemoveFromOtherButtons(buttonOne);
    }

    // Equip to Slot Two Button
    public void SlotTwo()
    {
        // This and other Slot buttons follow the same pattern as SlotOne
        buttonTwo.myTurret = currentUnit;

        GetTurretNum(buttonTwo);
        PlayerStats.equippedTurretTwo = turretNum;

        RemoveFromOtherButtons(buttonTwo);
    }

    // Equip to Slot Three Button
    public void SlotThree()
    {
        buttonThree.myTurret = currentUnit;

        GetTurretNum(buttonThree);
        PlayerStats.equippedTurretThree = turretNum;

        RemoveFromOtherButtons(buttonThree);
    }

    // Equip to Slot Four Button
    public void SlotFour()
    {
        buttonFour.myTurret = currentUnit;

        GetTurretNum(buttonFour);
        PlayerStats.equippedTurretFour = turretNum;

        RemoveFromOtherButtons(buttonFour);
    }

    // Equip to Slot Five Button
    public void SlotFive()
    {
        buttonFive.myTurret = currentUnit;

        GetTurretNum(buttonFive);
        PlayerStats.equippedTurretFive = turretNum;

        RemoveFromOtherButtons(buttonFive);
    }

    void GetTurretNum(EquippedTurretButton button)
    {
        if (button.myTurret.name == "Basic Turret")
        {
            turretNum = 1;
        }
        else if (button.myTurret.name == "Sniper Turret")
        {
            turretNum = 2;
        }
        else if (button.myTurret.name == "Slugger Turret")
        {
            turretNum = 3;
        }
        else if (button.myTurret.name == "Spitter Turret")
        {
            turretNum = 4;
        }
        else if (button.myTurret.name == "Farm")
        {
            turretNum = 5;
        }
    }

    public void RemoveFromOtherButtons(EquippedTurretButton slot)
    {
        // If the button passed in was the first EquippedTurretButton
        if (slot == buttonOne)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonOne.myTurret)
            {
                PlayerStats.equippedTurretTwo = 0;
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonOne.myTurret)
            {
                PlayerStats.equippedTurretThree = 0;
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonOne.myTurret)
            {
                PlayerStats.equippedTurretFour = 0;
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonOne.myTurret)
            {
                PlayerStats.equippedTurretFive = 0;
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the second CurrentTurretButton
        else if (slot == buttonTwo)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonOne.myTurret == buttonTwo.myTurret)
            {
                PlayerStats.equippedTurretOne = 0;
                buttonOne.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonTwo.myTurret)
            {
                PlayerStats.equippedTurretThree = 0;
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonTwo.myTurret)
            {
                PlayerStats.equippedTurretFour = 0;
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonTwo.myTurret)
            {
                PlayerStats.equippedTurretFive = 0;
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the third CurrentTurretButton
        else if (slot == buttonThree)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonThree.myTurret)
            {
                PlayerStats.equippedTurretTwo = 0;
                buttonTwo.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonThree.myTurret)
            {
                PlayerStats.equippedTurretOne = 0;
                buttonOne.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonThree.myTurret)
            {
                PlayerStats.equippedTurretFour = 0;
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonThree.myTurret)
            {
                PlayerStats.equippedTurretFive = 0;
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the fourth CurrentTurretButton
        else if (slot == buttonFour)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonFour.myTurret)
            {
                PlayerStats.equippedTurretTwo = 0;
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonFour.myTurret)
            {
                PlayerStats.equippedTurretThree = 0;
                buttonThree.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonFour.myTurret)
            {
                PlayerStats.equippedTurretOne = 0;
                buttonOne.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonFour.myTurret)
            {
                PlayerStats.equippedTurretFive = 0;
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the fifth CurrentTurretButton
        else if (slot == buttonFive)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonFive.myTurret)
            {
                PlayerStats.equippedTurretTwo = 0;
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonFive.myTurret)
            {
                PlayerStats.equippedTurretThree = 0;
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonFive.myTurret)
            {
                PlayerStats.equippedTurretFour = 0;
                buttonFour.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonFive.myTurret)
            {
                PlayerStats.equippedTurretOne = 0;
                buttonOne.myTurret = null;
            }
        }
    }
}
