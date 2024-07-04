using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int enemiesAlive;

    public Wave[] waves;
    
    private int waveIndex = 0;
    private int waveCount;

    public float countdown;
    public float timeBetweenWaves;

    public TextMeshProUGUI countdownText;

    void Start()
    {
        enemiesAlive = 0;
        waveCount = waves.Count();
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
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        Wave waveToSpawn = waves[waveIndex];

        // For each enemy type
        for (int x = 0; x < waveToSpawn.enemies.Count(); x++)
        {
            int amountToSpawn = waveToSpawn.amounts[x];
                
            // For each amount of each enemy
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
