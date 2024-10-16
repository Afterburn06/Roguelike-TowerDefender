using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI statText;
    public GameObject currentUnit;

    public CurrentUnitButton buttonOne;
    public CurrentUnitButton buttonTwo;
    public CurrentUnitButton buttonThree;
    public CurrentUnitButton buttonFour;
    public CurrentUnitButton buttonFive;

    public void SlotOne()
    {
        buttonOne.myUnit = currentUnit;
        RemoveFromOtherButtons(buttonOne);
    }

    public void SlotTwo()
    {
        buttonTwo.myUnit = currentUnit;
        RemoveFromOtherButtons(buttonTwo);
    }

    public void SlotThree()
    {
        buttonThree.myUnit = currentUnit;
        RemoveFromOtherButtons(buttonThree);
    }

    public void SlotFour()
    {
        buttonFour.myUnit = currentUnit;
        RemoveFromOtherButtons(buttonFour);
    }

    public void SlotFive()
    {
        buttonFive.myUnit = currentUnit;
        RemoveFromOtherButtons(buttonFive);
    }

    public void RemoveFromOtherButtons(CurrentUnitButton slot)
    {
        if (slot == buttonOne)
        {
            if (buttonTwo.myUnit == buttonOne.myUnit)
            {
                buttonTwo.myUnit = null;
            }
            else if (buttonThree.myUnit == buttonOne.myUnit)
            {
                buttonThree.myUnit = null;
            }
            else if (buttonFour.myUnit == buttonOne.myUnit)
            {
                buttonFour.myUnit = null;
            }
            else if (buttonFive.myUnit == buttonOne.myUnit)
            {
                buttonFive.myUnit = null;
            }
        }
        else if (slot == buttonTwo)
        {
            if (buttonOne.myUnit == buttonTwo.myUnit)
            {
                buttonOne.myUnit = null;
            }
            else if (buttonThree.myUnit == buttonTwo.myUnit)
            {
                buttonThree.myUnit = null;
            }
            else if (buttonFour.myUnit == buttonTwo.myUnit)
            {
                buttonFour.myUnit = null;
            }
            else if (buttonFive.myUnit == buttonTwo.myUnit)
            {
                buttonFive.myUnit = null;
            }
        }
        else if (slot == buttonThree)
        {
            if (buttonTwo.myUnit == buttonThree.myUnit)
            {
                buttonTwo.myUnit = null;
            }
            else if (buttonOne.myUnit == buttonThree.myUnit)
            {
                buttonOne.myUnit = null;
            }
            else if (buttonFour.myUnit == buttonThree.myUnit)
            {
                buttonFour.myUnit = null;
            }
            else if (buttonFive.myUnit == buttonThree.myUnit)
            {
                buttonFive.myUnit = null;
            }
        }
        else if (slot == buttonFour)
        {
            if (buttonTwo.myUnit == buttonFour.myUnit)
            {
                buttonTwo.myUnit = null;
            }
            else if (buttonThree.myUnit == buttonFour.myUnit)
            {
                buttonThree.myUnit = null;
            }
            else if (buttonOne.myUnit == buttonFour.myUnit)
            {
                buttonOne.myUnit = null;
            }
            else if (buttonFive.myUnit == buttonFour.myUnit)
            {
                buttonFive.myUnit = null;
            }
        }
        else if (slot == buttonFive)
        {
            if (buttonTwo.myUnit == buttonFive.myUnit)
            {
                buttonTwo.myUnit = null;
            }
            else if (buttonThree.myUnit == buttonFive.myUnit)
            {
                buttonThree.myUnit = null;
            }
            else if (buttonFour.myUnit == buttonFive.myUnit)
            {
                buttonFour.myUnit = null;
            }
            else if (buttonOne.myUnit == buttonFive.myUnit)
            {
                buttonOne.myUnit = null;
            }
        }
    }
}
