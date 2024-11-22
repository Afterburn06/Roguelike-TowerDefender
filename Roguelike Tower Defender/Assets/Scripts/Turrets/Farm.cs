using UnityEngine;

public class Farm : Turret
{
    private EnemySpawner enemySpawner;

    private int lastWave;

    private int moneyProduced;

    [Header("Money Produced")]
    public int levelOneMoneyProduced;
    public int levelTwoMoneyProduced;
    public int levelThreeMoneyProduced;
    public int levelFourMoneyProduced;
    public int levelFiveMoneyProduced;

    protected override void Start()
    {
        // Remove Turret script Start() functionality

        // New functionality
        enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();

        lastWave = 1;
    }

    protected override void Update()
    {
        // Remove Turret script Update() functionality

        // New functionality
        switch (level)
        {
            case 1:
                moneyProduced = levelOneMoneyProduced;
                break;
            case 2:
                moneyProduced = levelTwoMoneyProduced;
                break;
            case 3:
                moneyProduced = levelThreeMoneyProduced;
                break;
            case 4:
                moneyProduced = levelFourMoneyProduced;
                break;
            case 5:
                moneyProduced = levelFiveMoneyProduced;
                break;
        }

        if (lastWave < enemySpawner.waveCount)
        {
            MoneyManager.currentMoney += moneyProduced;
            lastWave = enemySpawner.waveCount;
        }
    }

    protected override void OnDrawGizmosSelected()
    {
        // Remove Turret script OnDrawGizmosSelected() functionality
    }
}
