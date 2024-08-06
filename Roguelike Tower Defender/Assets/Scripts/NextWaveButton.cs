using UnityEngine;

public class NextWaveButton : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public static bool canSkip;

    void Start()
    {
        canSkip = true;
        this.gameObject.SetActive(false);

        enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();
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
