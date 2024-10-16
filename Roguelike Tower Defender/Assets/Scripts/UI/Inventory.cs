using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Header("Buttons")]
    public CurrentUnitButton buttonOne;
    public CurrentUnitButton buttonTwo;
    public CurrentUnitButton buttonThree;
    public CurrentUnitButton buttonFour;
    public CurrentUnitButton buttonFive;

    [Header("Units")]
    public static GameObject unitOne;
    public static GameObject unitTwo;
    public static GameObject unitThree;
    public static GameObject unitFour;
    public static GameObject unitFive;

    public void Exit()
    {
        unitOne = buttonOne.myUnit;
        unitTwo = buttonTwo.myUnit;
        unitThree = buttonThree.myUnit;
        unitFour = buttonFour.myUnit;
        unitFive = buttonFive.myUnit;

        SceneManager.LoadScene("IngameMenu");
    }
}
