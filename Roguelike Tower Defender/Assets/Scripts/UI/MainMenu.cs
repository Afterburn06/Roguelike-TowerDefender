using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject creditsUI;
    public TextMeshProUGUI continueText;

    [Header("Turret Prefabs")]
    public GameObject basicTurret;
    public GameObject sniperTurret;
    public GameObject sluggerTurret;
    public GameObject spitterTurret;
    public GameObject farmTurret;

    [Header("Buttons")]
    public Button continueButton;
    public Button newGameButton;
    public Button creditsButton;
    public Button quitButton;
    public Button closeButton;

    public void Credits()
    {
        // Enable credits UI
        creditsUI.SetActive(true);

        // Disable buttons
        newGameButton.interactable = false;
        creditsButton.interactable = false;
        continueButton.interactable = false;
        quitButton.interactable = false;
    }

    public void Close()
    {
        // Disable credits UI
        creditsUI.SetActive(false);

        // Enable buttons
        newGameButton.interactable = true;
        creditsButton.interactable = true;
        continueButton.interactable = true;
        quitButton.interactable = true;
    }

    // New Game Button
    public void NewGame()
    {
        // Reset all stats
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

        // Load the in game menu
        SceneManager.LoadScene("IngameMenu");
    }

    public void Continue()
    {
        // Try to execute code below
        try
        {
            // Load player data
            PlayerData data = SaveSystem.LoadPlayer();

            // Set PlayerStats variables based on the data
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

            // If PlayerStats first equipped turret number is 1
            if (PlayerStats.equippedTurretOne == 1)
            {
                // Set the inventory turret one to the basic turret
                Inventory.turretOne = basicTurret;
            }
            // If PlayerStats first equipped turret number is 2
            else if (PlayerStats.equippedTurretOne == 2)
            {
                // Set the inventory turret one to the sniper turret
                Inventory.turretOne = sniperTurret;
            }
            // If PlayerStats first equipped turret number is 3
            else if (PlayerStats.equippedTurretOne == 3)
            {
                // Set the inventory turret one to the slugger turret
                Inventory.turretOne = sluggerTurret;
            }
            // If PlayerStats first equipped turret number is 4
            else if (PlayerStats.equippedTurretOne == 4)
            {
                // Set the inventory turret one to the spitter turret
                Inventory.turretOne = spitterTurret;
            }
            // If PlayerStats first equipped turret number is 5
            else if (PlayerStats.equippedTurretOne == 5)
            {
                // Set the inventory turret one to the farm
                Inventory.turretOne = farmTurret;
            }

            // The rest of the if else if statements follow the same pattern as the first one, just for different Inventory turrets
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

            // Load the in game menu
            SceneManager.LoadScene("IngameMenu");
        }
        // If the above code fails
        catch (System.Exception)
        {
            // Disable the continue button
            continueButton.interactable = false;
            // Tell the player to create a new game
            continueText.text = "Please create a new game.";
        }
    }

    public void Quit()
    {
        // Close the app
        Application.Quit();
    }
}
