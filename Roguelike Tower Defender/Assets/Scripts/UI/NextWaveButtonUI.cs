using UnityEngine;

public class NextWaveButtonUI : MonoBehaviour
{
    public static bool canSkip;

    [Header("Spawner")]
    public EnemySpawner enemySpawner;

    void Start()
    {
        // Allow waves to be skipped
        canSkip = true;
        // Disable Skip UI
        this.gameObject.SetActive(false);
    }

    // Yes Button
    public void Yes()
    {
        // Spawn the next wave
        enemySpawner.NextWave();
        // Disable Skip UI
        this.gameObject.SetActive(false);
    }

    // No Button
    public void No()
    {
        // Do not allow waves to be skipped
        canSkip = false;
        // Disable Skip UI
        this.gameObject.SetActive(false);
    }
}
