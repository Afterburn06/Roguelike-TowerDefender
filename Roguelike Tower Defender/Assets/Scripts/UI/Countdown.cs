using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float currentCountdown;
    
    public static bool setupComplete;
    public int setupTime;

    public TextMeshProUGUI countdownText;
    public GameObject nextWaveButton;
    private EnemySpawner spawner;

    void Start()
    {
        spawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();

        setupComplete = false;
        currentCountdown = setupTime;
    }

    void Update()
    {
        if (!MapGenerator.loaded || GameManager.gameOver)
        {
            return;
        }

        currentCountdown -= Time.deltaTime;
        currentCountdown = Mathf.Clamp(currentCountdown, 0f, Mathf.Infinity);

        countdownText.text = string.Format("{0:0}", currentCountdown);

        if (!setupComplete && currentCountdown == 0)
        {
            setupComplete = true;
        }

        if (setupComplete && currentCountdown < spawner.waveCountdown / 3 && spawner.waveIndex != spawner.waves.Length && NextWaveButtonUI.canSkip)
        {
            nextWaveButton.SetActive(true);
        }
        else
        {
            nextWaveButton.SetActive(false);
        }
    }
}
