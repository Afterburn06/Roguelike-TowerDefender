using UnityEngine;

public class NextWaveButtonUI : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public static bool canSkip;

    void Start()
    {
        canSkip = true;
        this.gameObject.SetActive(false);
    }

    public void Yes()
    {
        enemySpawner.NextWave();
        this.gameObject.SetActive(false);
    }

    public void No()
    {
        canSkip = false;
        this.gameObject.SetActive(false);
    }
}
