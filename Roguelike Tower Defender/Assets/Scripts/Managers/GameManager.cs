using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public EnemySpawner spawner;
    public float amountOneEarned;
    public float amountTwoEarned;

    [Header("UI Elements")]
    public GameObject gameOverUI;
    public TextMeshProUGUI wavesReachedText;
    public TextMeshProUGUI turretUnlockedText;
    public TextMeshProUGUI amountOne;
    public TextMeshProUGUI amountTwo;
    public Button menuButton;

    void Start()
    {
        // Reset the gameOver variable
        gameOverUI.SetActive(false);
        gameOver = false;
    }

    void Update()
    {
        // If the player's health reaches zero
        if (PlayerStats.playerHealth == 0)
        {
            GameOver();          
        }

        if (EnemySpawner.enemiesAlive == 0 && spawner.waveCount == 20)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;

        Time.timeScale = 0;
        gameOverUI.SetActive(true);

        amountOneEarned = spawner.waveCount;
        amountTwoEarned = spawner.waveCount / 5;

        Mathf.FloorToInt(amountTwoEarned);

        PlayerStats.materialOneAmount += (int)amountOneEarned;
        PlayerStats.materialTwoAmount += (int)amountTwoEarned;

        wavesReachedText.text = "Wave Reached: " + spawner.waveCount.ToString();
        amountOne.text = amountOneEarned.ToString();
        amountTwo.text = amountTwo.ToString();

        if (spawner.waveCount >= 5)
        {
            if (spawner.waveCount < 10 && !PlayerStats.sluggerUnlocked)
            {
                turretUnlockedText.text = "Slugger Turret Unlocked!";
                PlayerStats.sluggerUnlocked = true;
            }
            else if (spawner.waveCount >= 10 && spawner.waveCount < 15 && !PlayerStats.sluggerUnlocked && !PlayerStats.farmUnlocked)
            {
                turretUnlockedText.text = "Slugger Turret Unlocked! Farm Unlocked!";
                PlayerStats.sluggerUnlocked = true;
                PlayerStats.farmUnlocked = true;
            }
            else if (spawner.waveCount >= 10 && spawner.waveCount < 15 && PlayerStats.sluggerUnlocked && !PlayerStats.farmUnlocked)
            {
                turretUnlockedText.text = "Farm Unlocked!";
                PlayerStats.farmUnlocked = true;
            }
            else if (spawner.waveCount >= 15 && !PlayerStats.sluggerUnlocked && !PlayerStats.farmUnlocked && !PlayerStats.spitterUnlocked)
            {
                turretUnlockedText.text = "Slugger Turret Unlocked! Farm Unlocked! Spitter Turret Unlocked!";
                PlayerStats.sluggerUnlocked = true;
                PlayerStats.farmUnlocked = true;
                PlayerStats.spitterUnlocked = true;
            }
            else if (spawner.waveCount >= 15 && PlayerStats.sluggerUnlocked && !PlayerStats.farmUnlocked && !PlayerStats.spitterUnlocked)
            {
                turretUnlockedText.text = "Farm Unlocked! Spitter Turret Unlocked!";
                PlayerStats.farmUnlocked = true;
                PlayerStats.spitterUnlocked = true;
            }
            else if (spawner.waveCount >= 15 && PlayerStats.sluggerUnlocked && PlayerStats.farmUnlocked && !PlayerStats.spitterUnlocked)
            {
                turretUnlockedText.text = "Spitter Turret Unlocked!";
                PlayerStats.spitterUnlocked = true;
            }
            else
            {
                turretUnlockedText.text = "";
            }
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("IngameMenu");
    }
}