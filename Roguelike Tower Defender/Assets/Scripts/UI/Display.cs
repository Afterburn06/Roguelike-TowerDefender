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
    public Image image;
    public TextMeshProUGUI statText;

    [HideInInspector]
    public GameObject currentUnit;

    // Equip to Slot One Button
    public void SlotOne()
    {
        // Set Button One's turret to the one assigned to this button
        buttonOne.myTurret = currentUnit;
        // Remove this turret from the 
        RemoveFromOtherButtons(buttonOne);
    }

    // Equip to Slot Two Button
    public void SlotTwo()
    {
        // This and other Slot buttons follow the same pattern as SlotOne
        buttonTwo.myTurret = currentUnit;
        RemoveFromOtherButtons(buttonTwo);
    }

    // Equip to Slot Three Button
    public void SlotThree()
    {
        buttonThree.myTurret = currentUnit;
        RemoveFromOtherButtons(buttonThree);
    }

    // Equip to Slot Four Button
    public void SlotFour()
    {
        buttonFour.myTurret = currentUnit;
        RemoveFromOtherButtons(buttonFour);
    }

    // Equip to Slot Five Button
    public void SlotFive()
    {
        buttonFive.myTurret = currentUnit;
        RemoveFromOtherButtons(buttonFive);
    }

    public void RemoveFromOtherButtons(EquippedTurretButton slot)
    {
        // If the button passed in was the first EquippedTurretButton
        if (slot == buttonOne)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonOne.myTurret)
            {
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonOne.myTurret)
            {
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonOne.myTurret)
            {
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonOne.myTurret)
            {
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the second CurrentTurretButton
        else if (slot == buttonTwo)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonOne.myTurret == buttonTwo.myTurret)
            {
                buttonOne.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonTwo.myTurret)
            {
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonTwo.myTurret)
            {
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonTwo.myTurret)
            {
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the third CurrentTurretButton
        else if (slot == buttonThree)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonThree.myTurret)
            {
                buttonTwo.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonThree.myTurret)
            {
                buttonOne.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonThree.myTurret)
            {
                buttonFour.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonThree.myTurret)
            {
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the fourth CurrentTurretButton
        else if (slot == buttonFour)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonFour.myTurret)
            {
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonFour.myTurret)
            {
                buttonThree.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonFour.myTurret)
            {
                buttonOne.myTurret = null;
            }
            else if (buttonFive.myTurret == buttonFour.myTurret)
            {
                buttonFive.myTurret = null;
            }
        }
        // If the button passed in was the fifth CurrentTurretButton
        else if (slot == buttonFive)
        {
            // Remove the turret just equipped from the other buttons
            if (buttonTwo.myTurret == buttonFive.myTurret)
            {
                buttonTwo.myTurret = null;
            }
            else if (buttonThree.myTurret == buttonFive.myTurret)
            {
                buttonThree.myTurret = null;
            }
            else if (buttonFour.myTurret == buttonFive.myTurret)
            {
                buttonFour.myTurret = null;
            }
            else if (buttonOne.myTurret == buttonFive.myTurret)
            {
                buttonOne.myTurret = null;
            }
        }
    }
}
