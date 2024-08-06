using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;

    public static int enemiesAlive;
    public int waveIndex;
    public float spawnRate;
    public float waveCountdown;

    private Countdown countdown;

    void Awake()
    {
        waveIndex = 0;
        enemiesAlive = 0;
    }

    void Start()
    {
        countdown = GameObject.Find("Enemy Spawner").GetComponent<Countdown>();
    }

    void Update()
    {
        if (!MapGenerator.loaded || !countdown.setupComplete)
        {
            return;
        }

        if (enemiesAlive > 0 && countdown.currentCountdown != 0)
        {
            return;
        }

        if (countdown.currentCountdown != 0 && enemiesAlive == 0)
        {
            StartCoroutine(SpawnWave());
            return;
        }

        StartCoroutine(SpawnWave());
        return;
    }

    IEnumerator SpawnWave()
    {
        Wave waveToSpawn = waves[waveIndex];
        countdown.currentCountdown = waveCountdown;
        NextWaveButton.canSkip = true;

        // For each enemy type
        for (int x = 0; x < waveToSpawn.enemies.Count(); x++)
        {
            int amountToSpawn = waveToSpawn.amounts[x];
                
            // For each amount of each type
            for (int y = 0; y < amountToSpawn; y++)
            {
                SpawnEnemy(waveToSpawn.enemies[x]);
                yield return new WaitForSeconds(spawnRate);
            }
            
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, MapGenerator.spawnPoint, Quaternion.identity);
        enemiesAlive++;
    }

    public void NextWave()
    {
        StartCoroutine(SpawnWave());
    }
}
