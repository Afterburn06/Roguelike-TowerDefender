using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Static Variables")]
    public static bool gameOver;
    public static bool gamePaused;

    [Header("UI Elements")]
    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI wavesReachedText;
    public TextMeshProUGUI turretUnlockedText;
    public TextMeshProUGUI amountOne;
    public TextMeshProUGUI amountTwo;
    public Button menuButton;
    public GameObject pauseUI;

    [Header("Other")]
    public EnemySpawner spawner;
    public float amountOneEarned;
    public float amountTwoEarned;

    void Start()
    {
        // Reset time scale
        Time.timeScale = 1;
        // Disable UI
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        // Set bools
        gameOver = false;
        gamePaused = false;
    }

    void Update()
    {
        // If the player's health reaches zero and the game is not over
        if (PlayerStats.playerHealth <= 0 && !gameOver)
        {
            // Set player health to 0
            PlayerStats.playerHealth = 0;
            // Call the GameOver method
            GameOver();          
        }

        // If there are no enemies alive and it's the final wave and the game is not over
        if (EnemySpawner.enemiesAlive == 0 && spawner.waveCount == 20 && !gameOver)
        {
            // Call the GameOver method
            GameOver();
        }

        // If in the level scene and ESC is pressed and the game is not over
        if (SceneManager.GetActiveScene().name == "Level" && Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            // If pause UI is already active
            if (pauseUI.activeInHierarchy)
            {
                // Reset time scale
                Time.timeScale = 1;
                // Disable UI
                pauseUI.SetActive(false);
                // Set bool
                gamePaused = false;
            }
            else if (!pauseUI.activeInHierarchy)
            {
                // Stop time passing
                Time.timeScale = 0;
                // Enable UI
                pauseUI.SetActive(true);
                // Set bool
                gamePaused = true;
            }
        }
    }

    public void Continue()
    {
        // Reset time scale
        Time.timeScale = 1;
        // Disable UI
        pauseUI.SetActive(false);
        // Set bool
        gamePaused = false;
    }

    void GameOver()
    {
        // Set bool
        gameOver = true;

        // Stop time passing
        Time.timeScale = 0;
        // Enable game over UI
        gameOverUI.SetActive(true);

        // If the necromancer died
        if (Necromancer.necromancerDead)
        {
            // Change the game over text to say You Win!
            gameOverText.text = "You Win!";
        }
        else
        {
            // Set game over text to say Game Over!
            gameOverText.text = "Game Over!";
        }

        // Set the currency earned based on the wave reached
        amountOneEarned = spawner.waveCount;
        amountTwoEarned = spawner.waveCount / 5;

        // Round the amount earned down
        Mathf.FloorToInt(amountTwoEarned);

        // Set the PlayerStats variable to itself plus the amounts of currency earned
        PlayerStats.materialOneAmount += (int)amountOneEarned;
        PlayerStats.materialTwoAmount += (int)amountTwoEarned;

        // Change text elements
        wavesReachedText.text = "Wave Reached: " + spawner.waveCount;
        amountOne.text = amountOneEarned.ToString();
        amountTwo.text = amountTwoEarned.ToString();

        // If the player passed wave 5 but not wave 10
        if (spawner.waveCount >= 5 && spawner.waveCount < 10)
        {
            // Set text element
            turretUnlockedText.text = "New Turret Unlocked!";
            // Unlock slugger turret
            PlayerStats.sluggerUnlocked = true;
        }
        // The player passed wave 10 but not wave 15
        else if (spawner.waveCount >= 10 && spawner.waveCount < 15)
        {
            // Set text element
            turretUnlockedText.text = "New Turret Unlocked!";
            // Unlock slugger turret and farm
            PlayerStats.sluggerUnlocked = true;
            PlayerStats.farmUnlocked = true;
        }
        // The player passed wave 15
        else if (spawner.waveCount >= 15)
        {
            // Set text element
            turretUnlockedText.text = "New Turret Unlocked!";
            // Unlock slugger and spitter turret and farm
            PlayerStats.sluggerUnlocked = true;
            PlayerStats.farmUnlocked = true;
            PlayerStats.spitterUnlocked = true;
        }
    }

    public void Menu()
    {
        // Load the in game menu
        SceneManager.LoadScene("IngameMenu");
    }
}