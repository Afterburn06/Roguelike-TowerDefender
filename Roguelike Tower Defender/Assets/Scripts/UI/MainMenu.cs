using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;

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

        SceneManager.LoadScene("IngameMenu");
    }

    public void Continue()
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

        SceneManager.LoadScene("IngameMenu");
    }
}
