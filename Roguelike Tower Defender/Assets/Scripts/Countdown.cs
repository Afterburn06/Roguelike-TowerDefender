using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float currentCountdown;
    
    public bool setupComplete;
    public int setupTime;

    public TextMeshProUGUI countdownText;
    private EnemySpawner spawner;
    public GameObject nextWaveButton;

    void Start()
    {
        spawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();

        setupComplete = false;
        currentCountdown = setupTime;
    }

    void Update()
    {
        if (!MapGenerator.loaded)
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

        if (setupComplete && currentCountdown < spawner.waveCountdown / 2 && spawner.waveIndex != spawner.waves.Length && NextWaveButton.canSkip)
        {
            nextWaveButton.SetActive(true);
        }
        else
        {
            nextWaveButton.SetActive(false);
        }
    }
}
