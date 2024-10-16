using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public GameObject unit;
    public Image image;
    public Display display;
    public TextMeshProUGUI myText;

    [Header("Current Unit Buttons")]
    public CurrentUnitButton buttonOne;
    public CurrentUnitButton buttonTwo;
    public CurrentUnitButton buttonThree;
    public CurrentUnitButton buttonFour;
    public CurrentUnitButton buttonFive;

    void Start()
    {
        if (unit != null)
        {
            myText.text = unit.name;
        }
        else
        {
            myText.text = "";
        }
    }

    public void OnClick()
    {
        display.currentUnit = unit;
        display.statText.text = unit.name;
    }
}
