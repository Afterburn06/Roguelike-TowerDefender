using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Header("Buttons")]
    public EquippedTurretButton buttonOne;
    public EquippedTurretButton buttonTwo;
    public EquippedTurretButton buttonThree;
    public EquippedTurretButton buttonFour;
    public EquippedTurretButton buttonFive;

    [Header("Turrets")]
    public static GameObject turretOne;
    public static GameObject turretTwo;
    public static GameObject turretThree;
    public static GameObject turretFour;
    public static GameObject turretFive;

    // Exit Button
    public void Exit()
    {
        // Set static variables to the turrets in the equipped turret buttons
        turretOne = buttonOne.myTurret;
        turretTwo = buttonTwo.myTurret;
        turretThree = buttonThree.myTurret;
        turretFour = buttonFour.myTurret;
        turretFive = buttonFive.myTurret;

        // Load In-game Menu
        SceneManager.LoadScene("IngameMenu");
    }
}
