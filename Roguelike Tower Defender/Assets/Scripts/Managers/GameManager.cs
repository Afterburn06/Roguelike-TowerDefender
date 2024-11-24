using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gamePaused;
    public EnemySpawner spawner;
    public float amountOneEarned;
    public float amountTwoEarned;

    [Header("UI Elements")]
    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI wavesReachedText;
    public TextMeshProUGUI turretUnlockedText;
    public TextMeshProUGUI amountOne;
    public TextMeshProUGUI amountTwo;
    public Button menuButton;
    public GameObject pauseUI;

    void Start()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOver = false;
        gamePaused = false;
    }

    void Update()
    {
        // If the player's health reaches zero
        if (PlayerStats.playerHealth <= 0 && !gameOver)
        {
            PlayerStats.playerHealth = 0;
            GameOver();          
        }

        if (EnemySpawner.enemiesAlive == 0 && spawner.waveCount == 20 && !gameOver)
        {
            GameOver();
        }

        if (SceneManager.GetActiveScene().name == "Level" && Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (pauseUI.activeInHierarchy)
            {
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                gamePaused = false;
            }
            else if (!pauseUI.activeInHierarchy)
            {
                Time.timeScale = 0;
                pauseUI.SetActive(true);
                gamePaused = true;
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gamePaused = false;
    }

    void GameOver()
    {
        gameOver = true;

        Time.timeScale = 0;
        gameOverUI.SetActive(true);

        if (Necromancer.necromancerDead)
        {
            gameOverText.text = "You Win!";
        }
        else
        {
            gameOverText.text = "Game Over!";
        }

        amountOneEarned = spawner.waveCount;
        amountTwoEarned = spawner.waveCount / 5;

        Mathf.FloorToInt(amountTwoEarned);

        PlayerStats.materialOneAmount += (int)amountOneEarned;
        PlayerStats.materialTwoAmount += (int)amountTwoEarned;

        wavesReachedText.text = "Wave Reached: " + spawner.waveCount;
        amountOne.text = amountOneEarned.ToString();
        amountTwo.text = amountTwoEarned.ToString();

        if (spawner.waveCount >= 5 && spawner.waveCount < 10)
        {
            turretUnlockedText.text = "New Turret Unlocked!";
            PlayerStats.sluggerUnlocked = true;
        }
        else if (spawner.waveCount >= 10 && spawner.waveCount < 15)
        {
            turretUnlockedText.text = "New Turret Unlocked!";
            PlayerStats.sluggerUnlocked = true;
            PlayerStats.farmUnlocked = true;
        }
        else if (spawner.waveCount >= 15)
        {
            turretUnlockedText.text = "New Turret Unlocked!";
            PlayerStats.sluggerUnlocked = true;
            PlayerStats.farmUnlocked = true;
            PlayerStats.spitterUnlocked = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("IngameMenu");
    }
}