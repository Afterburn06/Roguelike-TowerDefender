using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public TextMeshProUGUI continueText;

    public GameObject basicTurret;
    public GameObject sniperTurret;
    public GameObject sluggerTurret;
    public GameObject spitterTurret;
    public GameObject farmTurret;

    // New Game Button
    public void NewGame()
    {
        PlayerStats.basicTier = 1;
        PlayerStats.sniperTier = 1;
        PlayerStats.sluggerTier = 1;
        PlayerStats.spitterTier = 1;
        PlayerStats.farmTier = 1;

        PlayerStats.materialOneAmount = 0;
        PlayerStats.materialTwoAmount = 0;

        PlayerStats.equippedTurretOne = 1;
        PlayerStats.equippedTurretTwo = 2;
        PlayerStats.equippedTurretThree = 0;
        PlayerStats.equippedTurretFour = 0;
        PlayerStats.equippedTurretFive = 0;

        PlayerStats.sluggerUnlocked = false;
        PlayerStats.spitterUnlocked = false;
        PlayerStats.farmUnlocked = false;

        Inventory.turretOne = basicTurret;
        Inventory.turretTwo = sniperTurret;

        SceneManager.LoadScene("IngameMenu");
    }

    public void Continue()
    {
        try
        {
            PlayerData data = SaveSystem.LoadPlayer();

            PlayerStats.basicTier = data.basicTier;
            PlayerStats.sniperTier = data.sniperTier;
            PlayerStats.sluggerTier = data.sluggerTier;
            PlayerStats.spitterTier = data.spitterTier;
            PlayerStats.farmTier = data.farmTier;

            PlayerStats.materialOneAmount = data.materialOneAmount;
            PlayerStats.materialTwoAmount = data.materialTwoAmount;

            PlayerStats.equippedTurretOne = data.equippedTurretOne;
            PlayerStats.equippedTurretTwo = data.equippedTurretTwo;
            PlayerStats.equippedTurretThree = data.equippedTurretThree;
            PlayerStats.equippedTurretFour = data.equippedTurretFour;
            PlayerStats.equippedTurretFive = data.equippedTurretFive;

            PlayerStats.sluggerUnlocked = data.sluggerUnlocked;
            PlayerStats.spitterUnlocked = data.spitterUnlocked;
            PlayerStats.farmUnlocked = data.farmUnlocked;

            if (PlayerStats.equippedTurretOne == 1)
            {
                Inventory.turretOne = basicTurret;
            }
            else if (PlayerStats.equippedTurretOne == 2)
            {
                Inventory.turretOne = sniperTurret;
            }
            else if (PlayerStats.equippedTurretOne == 3)
            {
                Inventory.turretOne = sluggerTurret;
            }
            else if (PlayerStats.equippedTurretOne == 4)
            {
                Inventory.turretOne = spitterTurret;
            }
            else if (PlayerStats.equippedTurretOne == 5)
            {
                Inventory.turretOne = farmTurret;
            }

            if (PlayerStats.equippedTurretTwo == 1)
            {
                Inventory.turretTwo = basicTurret;
            }
            else if (PlayerStats.equippedTurretTwo == 2)
            {
                Inventory.turretTwo = sniperTurret;
            }
            else if (PlayerStats.equippedTurretTwo == 3)
            {
                Inventory.turretTwo = sluggerTurret;
            }
            else if (PlayerStats.equippedTurretTwo == 4)
            {
                Inventory.turretTwo = spitterTurret;
            }
            else if (PlayerStats.equippedTurretTwo == 5)
            {
                Inventory.turretTwo = farmTurret;
            }

            if (PlayerStats.equippedTurretThree == 1)
            {
                Inventory.turretThree = basicTurret;
            }
            else if (PlayerStats.equippedTurretThree == 2)
            {
                Inventory.turretThree = sniperTurret;
            }
            else if (PlayerStats.equippedTurretThree == 3)
            {
                Inventory.turretThree = sluggerTurret;
            }
            else if (PlayerStats.equippedTurretThree == 4)
            {
                Inventory.turretThree = spitterTurret;
            }
            else if (PlayerStats.equippedTurretThree == 5)
            {
                Inventory.turretThree = farmTurret;
            }

            if (PlayerStats.equippedTurretFour == 1)
            {
                Inventory.turretFour = basicTurret;
            }
            else if (PlayerStats.equippedTurretFour == 2)
            {
                Inventory.turretFour = sniperTurret;
            }
            else if (PlayerStats.equippedTurretFour == 3)
            {
                Inventory.turretFour = sluggerTurret;
            }
            else if (PlayerStats.equippedTurretFour == 4)
            {
                Inventory.turretFour = spitterTurret;
            }
            else if (PlayerStats.equippedTurretFour == 5)
            {
                Inventory.turretFour = farmTurret;
            }

            if (PlayerStats.equippedTurretFive == 1)
            {
                Inventory.turretFive = basicTurret;
            }
            else if (PlayerStats.equippedTurretFive == 2)
            {
                Inventory.turretFive = sniperTurret;
            }
            else if (PlayerStats.equippedTurretFive == 3)
            {
                Inventory.turretFive = sluggerTurret;
            }
            else if (PlayerStats.equippedTurretFive == 4)
            {
                Inventory.turretFive = spitterTurret;
            }
            else if (PlayerStats.equippedTurretFive == 5)
            {
                Inventory.turretFive = farmTurret;
            }

            SceneManager.LoadScene("IngameMenu");
        }
        catch (System.Exception)
        {
            continueButton.interactable = false;
            continueText.text = "Please create a new game.";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
