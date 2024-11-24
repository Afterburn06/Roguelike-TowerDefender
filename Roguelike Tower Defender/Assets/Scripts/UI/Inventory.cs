using TMPro;
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

    [Header("Turret Prefabs")]
    public GameObject basicTurret;
    public GameObject sniperTurret;
    public GameObject sluggerTurret;
    public GameObject spitterTurret;
    public GameObject farmTurret;

    [Header("Materials")]
    public TextMeshProUGUI materialOneText;
    public TextMeshProUGUI materialTwoText;
    public static int materialOneAmount;
    public static int materialTwoAmount;

    void Start()
    {
        // If the PlayerStats slot one turret numer is 0
        if (PlayerStats.equippedTurretOne == 0)
        {
            // Remove the turret from button one
            buttonOne.myTurret = null;
        }
        // If the PlayerStats slot one turret numer is 1
        else if (PlayerStats.equippedTurretOne == 1)
        {
            // Set the turret in the buttons to the basic turret
            turretOne = basicTurret;
            buttonOne.myTurret = basicTurret;
        }
        // If the PlayerStats slot one turret numer is 2
        else if (PlayerStats.equippedTurretOne == 2)
        {
            // Set the turret in the buttons to the sniper turret
            turretOne = sniperTurret;
            buttonOne.myTurret = sniperTurret;
        }
        // If the PlayerStats slot one turret numer is 3
        else if (PlayerStats.equippedTurretOne == 3)
        {
            // Set the turret in the buttons to the slugger turret
            turretOne = sluggerTurret;
            buttonOne.myTurret = sluggerTurret;
        }
        // If the PlayerStats slot one turret numer is 4
        else if (PlayerStats.equippedTurretOne == 4)
        {
            // Set the turret in the buttons to the spitter turret
            turretOne = spitterTurret;
            buttonOne.myTurret = spitterTurret;
        }
        // If the PlayerStats slot one turret numer is 5
        else if (PlayerStats.equippedTurretOne == 5)
        {
            // Set the turret in the buttons to the farm
            turretOne = farmTurret;
            buttonOne.myTurret = farmTurret;
        }

        // Rest of the if else if statements follow the same pattern, just for different buttons
        if (PlayerStats.equippedTurretTwo == 0)
        {
            buttonTwo.myTurret = null;
        }
        else if (PlayerStats.equippedTurretTwo == 1)
        {
            turretTwo = basicTurret;
            buttonTwo.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 2)
        {
            turretTwo = sniperTurret;
            buttonTwo.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 3)
        {
            turretTwo = sluggerTurret;
            buttonTwo.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 4)
        {
            turretTwo = spitterTurret;
            buttonTwo.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 5)
        {
            turretTwo = farmTurret;
            buttonTwo.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretThree == 0)
        {
            buttonThree.myTurret = null;
        }
        else if (PlayerStats.equippedTurretThree == 1)
        {
            turretThree = basicTurret;
            buttonThree.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretThree == 2)
        {
            turretThree = sniperTurret;
            buttonThree.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretThree == 3)
        {
            turretThree = sluggerTurret;
            buttonThree.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretThree == 4)
        {
            turretThree = spitterTurret;
            buttonThree.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretThree == 5)
        {
            turretThree = farmTurret;
            buttonThree.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretFour == 0)
        {
            buttonFour.myTurret = null;
        }
        else if (PlayerStats.equippedTurretFour == 1)
        {
            turretFour = basicTurret;
            buttonFour.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretFour == 2)
        {
            turretFour = sniperTurret;
            buttonFour.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretFour == 3)
        {
            turretFour = sluggerTurret;
            buttonFour.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretFour == 4)
        {
            turretFour = spitterTurret;
            buttonFour.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretFour == 5)
        {
            turretFour = farmTurret;
            buttonFour.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretFive == 0)
        {
            buttonFive.myTurret = null;
        }
        else if (PlayerStats.equippedTurretFive == 1)
        {
            turretFive = basicTurret;
            buttonFive.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretFive == 2)
        {
            turretFive = sniperTurret;
            buttonFive.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretFive == 3)
        {
            turretFive = sluggerTurret;
            buttonFive.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretFive == 4)
        {
            turretFive = spitterTurret;
            buttonFive.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretFive == 5)
        {
            turretFive = farmTurret;
            buttonFive.myTurret = farmTurret;
        }
    }

    void Update()
    {
        // Change the text elements
        materialOneText.text = PlayerStats.materialOneAmount.ToString();
        materialTwoText.text = PlayerStats.materialTwoAmount.ToString();
    }

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
