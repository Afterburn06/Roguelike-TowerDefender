using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;

    public static int enemiesAlive;
    private int waveIndex = 0;

    private float waveCountdown;
    public float timeBetweenWaves;

    public TextMeshProUGUI countdownText;

    void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if (!MapGenerator.loaded)
        {
            return;
        }

        if (enemiesAlive > 0)
        {
            return;
        }
        
        if (waveCountdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveCountdown = timeBetweenWaves;
            return;
        }
        
        waveCountdown -= Time.deltaTime;
        waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", waveCountdown);
    }

    IEnumerator SpawnWave()
    {
        Wave waveToSpawn = waves[waveIndex];

        // For each enemy type
        for (int x = 0; x < waveToSpawn.enemies.Count(); x++)
        {
            int amountToSpawn = waveToSpawn.amounts[x];
                
            // For each amount of each type
            for (int y = 0; y < amountToSpawn; y++)
            {
                SpawnEnemy(waveToSpawn.enemies[x]);
                yield return new WaitForSeconds(waveToSpawn.rate);
            }
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }

        yield return new WaitForSeconds(timeBetweenWaves);
    }

    void SpawnEnemy(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, MapGenerator.spawnPoint, Quaternion.identity);
        enemiesAlive++;
    }
}
