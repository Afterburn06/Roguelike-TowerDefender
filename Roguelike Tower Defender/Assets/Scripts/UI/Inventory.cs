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

    public GameObject basicTurret;
    public GameObject sniperTurret;
    public GameObject sluggerTurret;
    public GameObject spitterTurret;
    public GameObject farmTurret;

    [Header("Materials")]
    public TextMeshProUGUI materialOneText;
    public TextMeshProUGUI materialTwoText;
    public int materialOneAmount;
    public int materialTwoAmount;

    void Start()
    {
        materialOneAmount = PlayerStats.materialOneAmount;
        materialTwoAmount = PlayerStats.materialTwoAmount;

        if (PlayerStats.equippedTurretOne == 0)
        {
            buttonOne.myTurret = null;
        }
        else if (PlayerStats.equippedTurretOne == 1)
        {
            buttonOne.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretOne == 2)
        {
            buttonOne.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretOne == 3)
        {
            buttonOne.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretOne == 4)
        {
            buttonOne.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretOne == 5)
        {
            buttonOne.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretTwo == 0)
        {
            buttonTwo.myTurret = null;
        }
        else if (PlayerStats.equippedTurretTwo == 1)
        {
            buttonTwo.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 2)
        {
            buttonTwo.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 3)
        {
            buttonTwo.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 4)
        {
            buttonTwo.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretTwo == 5)
        {
            buttonTwo.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretThree == 0)
        {
            buttonThree.myTurret = null;
        }
        else if (PlayerStats.equippedTurretThree == 1)
        {
            buttonThree.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretThree == 2)
        {
            buttonThree.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretThree == 3)
        {
            buttonThree.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretThree == 4)
        {
            buttonThree.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretThree == 5)
        {
            buttonThree.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretFour == 0)
        {
            buttonFour.myTurret = null;
        }
        else if (PlayerStats.equippedTurretFour == 1)
        {
            buttonFour.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretFour == 2)
        {
            buttonFour.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretFour == 3)
        {
            buttonFour.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretFour == 4)
        {
            buttonFour.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretFour == 5)
        {
            buttonFour.myTurret = farmTurret;
        }

        if (PlayerStats.equippedTurretFive == 0)
        {
            buttonFive.myTurret = null;
        }
        else if (PlayerStats.equippedTurretFive == 1)
        {
            buttonFive.myTurret = basicTurret;
        }
        else if (PlayerStats.equippedTurretFive == 2)
        {
            buttonFive.myTurret = sniperTurret;
        }
        else if (PlayerStats.equippedTurretFive == 3)
        {
            buttonFive.myTurret = sluggerTurret;
        }
        else if (PlayerStats.equippedTurretFive == 4)
        {
            buttonFive.myTurret = spitterTurret;
        }
        else if (PlayerStats.equippedTurretFive == 5)
        {
            buttonFive.myTurret = farmTurret;
        }
    }

    void Update()
    {
        materialOneText.text = materialOneAmount.ToString();
        materialTwoText.text = materialTwoAmount.ToString();
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
