using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int enemiesAlive;

    [Header("Waves")]
    public Wave[] waves;
    public int waveIndex;

    [Header("Enemy Spawn Rate")]
    public float spawnRate;

    [Header("Time Per Wave")]
    public float waveCountdown;

    private Countdown countdown;

    void Awake()
    {
        // Reset the count of the wave and the enemies alive
        waveIndex = 0;
        enemiesAlive = 0;
    }

    void Start()
    {
        // Get the Countdown script in this scene
        countdown = GameObject.Find("Enemy Spawner").GetComponent<Countdown>();
    }

    void Update()
    {
        // If the map is not loaded or the setup time is not over or the game is over
        if (!MapGenerator.loaded || !Countdown.setupComplete || GameManager.gameOver)
        {
            // Do not execute any more code
            return;
        }

        // If there are enemies alive and the countdown is not zero
        if (enemiesAlive > 0 && countdown.currentCountdown != 0)
        {
            // Do not execute any more code
            return;
        }

        // If the countdown is not zero but enemies are not alive
        if (countdown.currentCountdown != 0 && enemiesAlive == 0)
        {
            // Spawn a wave
            StartCoroutine(SpawnWave());
            // Do not execute any more code
            return;
        }

        // Spawn a wave
        StartCoroutine(SpawnWave());
        return;
    }

    IEnumerator SpawnWave()
    {
        // Get the wave to spawn from the array of waves
        Wave waveToSpawn = waves[waveIndex];
        // Set the countdown to the time allotted for this wave
        countdown.currentCountdown = waveCountdown;
        // Allow the wave to be skipped
        NextWaveButtonUI.canSkip = true;

        // For each enemy type
        for (int x = 0; x < waveToSpawn.enemies.Count(); x++)
        {
            // Get the amount to spawn from the array of values
            int amountToSpawn = waveToSpawn.amounts[x];
                
            // For each amount of each type
            for (int y = 0; y < amountToSpawn; y++)
            {
                // Spawn an enemy
                SpawnEnemy(waveToSpawn.enemies[x]);
                // Wait a specified amount of time
                yield return new WaitForSeconds(spawnRate);
            }
        }

        // Add one to the count of waves spawned
        waveIndex++;

        // If the final wave has been spawned
        if (waveIndex == waves.Length)
        {
            // Disable this
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemyToSpawn)
    {
        // Instantiate the enemy at the spawn point
        Instantiate(enemyToSpawn, MapGenerator.spawnPoint, Quaternion.identity);
        // Add one to the count of enemies to spawn
        enemiesAlive++;
    }

    // When the next wave button is clicked this is called
    public void NextWave()
    {
        // Spawn the next wave
        StartCoroutine(SpawnWave());
    }
}
